using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
    public bool isRotate
    {
        get;
        set;
    }
    private RaycastHit hit;
    private bool tapToMove;

    private Animator playerAnim;
    private bool isChecking;

    [SerializeField] private NavMeshAgent player;
    [SerializeField] private GameObject targetMark;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject camera;
    void Start()
    // Start is called before the first frame update
    {
        //lr = GetComponent<LineRenderer>();
        playerAnim = GetComponent<Animator>();
        isRotate = false;
        tapToMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotate || GameEventManager.isTouchObject)
        {
            //if(player.hasPath)
            //{
            //    player.isStopped = true;
            //    player.ResetPath();
            //}
            return;
        }

        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began /*&& !GameEventManager.isTouchObject*/)
            {
                tapToMove = true;
            }

            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                tapToMove = false;
            }

            if(tapToMove)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    Ray touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                
                    if (Physics.Raycast(touchRay, out hit, rayDistance, groundLayer))
                    {
                        if(!hit.collider.CompareTag("Obstacles"))
                        {
                            player.SetDestination(hit.point);
                            if(player.hasPath)
                            {
                                StopCoroutine(Move());
                                StartCoroutine(Move());
                            }
                            else
                            {
                                StartCoroutine(Move());
                            }
                        }
                        //StartCoroutine(visualizeMovement());
                
                    }
                }

            }
        }

        //for (var i = 0; i < Input.touchCount; ++i)
        //{
        //    if (Input.GetTouch(i).phase == TouchPhase.Began && !GameEventManager.isTouchObject)
        //    {
        //        if (Input.GetTouch(i).tapCount == 2)
        //        {
        //            Ray touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        //            if (Physics.Raycast(touchRay, out hit))
        //            {
        //                player.SetDestination(hit.point);
        //            }
        //        }
        //    }
        //}

    }
    private IEnumerator Move()
    {
        yield return new WaitForSeconds(0.1f);
        targetMark.transform.position = player.pathEndPosition;
        targetMark.gameObject.SetActive(true);

        if(camera.transform.localEulerAngles.y == 90.0f || camera.transform.localEulerAngles.y == 270.0f)
        {
            checkRotZ();
        }
        else
        {
            checkRotX();
        }

        if (!isChecking)
        {
            playerAnim.SetTrigger("isMoving");
            StartCoroutine(checkMove());
        }
    }
    private IEnumerator checkMove()
    {
        isChecking = true;
        while (player.hasPath && player.velocity.magnitude > 0)
        {
            yield return null;
        }
        playerAnim.SetTrigger("Stop");
        targetMark.gameObject.SetActive(false);
        isChecking = false;
    }

    private void checkRotX()
    {
        float playerposX = gameObject.transform.position.x;
        if (playerposX > player.pathEndPosition.x)// if going left
        {
            if (gameObject.transform.localEulerAngles.y <= 0)// if already facing right
            {
                gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.localEulerAngles.y + 180, 0); //face left
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.localEulerAngles.y, 0);//keep facing left
            }
        }
        else if (playerposX < player.pathEndPosition.x) // if going right
        {
            if (gameObject.transform.localEulerAngles.y <= 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.localEulerAngles.y, 0); // keep facing right
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.localEulerAngles.y - 180, 0); // face right

            }
        }
    }

    private void checkRotZ()
    {
        float playerposZ = gameObject.transform.position.z;
        if (playerposZ < player.pathEndPosition.z)// if going left
        {
            if (gameObject.transform.localEulerAngles.y < 270)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.localEulerAngles.y + 180, 0); // keep facing left
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.localEulerAngles.y, 0); // face left
            }
        }
        else if (playerposZ > player.pathEndPosition.z) // if going right
        {
            if (gameObject.transform.localEulerAngles.y > 90)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.localEulerAngles.y - 180, 0); // keep facing right
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.localEulerAngles.y, 0); // face right

            }
        }
    }
    //private IEnumerator visualizeMovement()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    int i = 1;
    //    //lr.positionCount = amtOfCorners;

    //    int amtOfCorners = player.path.corners.Length;
    //    points = player.path.corners.ToList();
    //    while (i < amtOfCorners)
    //    {
    //        for (int j = 0; j < points.Count; j++)
    //        {
    //            lr.SetPosition(j, points[j]);
    //        }
    //        i++;
    //    }
    //}
    //void checkForSlopes()
    //{
    //    if (points[0].y < points[1].y) // going up
    //    {
    //        Vector3 distance = points[1] - points[0];

    //        //float length = distance.magnitude;


    //        if(startpos.y < transform.position.y)
    //        {
    //            startpos = new Vector3(transform.position.x,transform.position.y / 2,transform.position.z);
    //        }

    //        //for(int i = 0; i < 2; i++)
    //        //{
    //            NavMesh.(1, startpos);
    //        //}

    //        lr.SetPositions(points.ToArray());

    //    }
    //    else if (points[0].y > points[1].y) // going down
    //    {

    //    }
    //    else
    //    {
    //        lr.SetPositions(points.ToArray());
    //    }

    //}
}
