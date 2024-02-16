using System.Collections;
using System.Collections.Generic;
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

    private List<Vector3> points = new List<Vector3>();

    private Animator playerAnim;
    private bool isChecking;

    [SerializeField] private NavMeshAgent player;
    [SerializeField] private GameObject targetMark;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask groundLayer;
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

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if(tapToMove)
                {
                    Ray touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                    if (Physics.Raycast(touchRay, out hit, rayDistance, groundLayer))
                    {
                        if(!hit.collider.CompareTag("Obstacles"))
                        {
                            player.SetDestination(hit.point);
                            //targetMark.transform.position = player.pathEndPosition;
                            if (!isChecking)
                            {
                                playerAnim.SetTrigger("isMoving");
                                //targetMark.gameObject.SetActive(true);
                                StartCoroutine(checkMove());    
                            }

                        }
                        //StartCoroutine(visualizeMovement());

                    }
                }
            }
        }

        if (player.velocity.magnitude > 0)
        {
            targetMark.transform.position = player.pathEndPosition;
            targetMark.gameObject.SetActive(true);
            //lr.positionCount = player.path.corners.Length;
            //lr.SetPositions(player.path.corners);
        }
        //else
        //{
        //    targetMark.gameObject.SetActive(false);
        //    //if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Walk animation"))
        //    //{
        //    //    playerAnim.SetBool("isMoving", false);
        //    //}
        //}

        //}

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

    private IEnumerator checkMove()
    {
        isChecking = true;
        //targetMark.transform.position = player.pathEndPosition;
        yield return new WaitForSeconds(0.1f);
        //while (player.velocity.magnitude > 0)
        //{
        //    yield return null;
        //}
        while (player.hasPath && player.velocity.magnitude > 0)
        {
            yield return null;
        }
        playerAnim.SetTrigger("Stop");
        targetMark.gameObject.SetActive(false);
        isChecking = false;
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
