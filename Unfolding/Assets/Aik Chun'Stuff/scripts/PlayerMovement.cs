using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Vector2 startTouchPos;
    private Vector2 EndTouchPos;

    [SerializeField] private NavMeshAgent player;
    void Start()
    // Start is called before the first frame update
    {
        isRotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotate)
        {
            //if(player.hasPath)
            //{
            //    player.isStopped = true;
            //    player.ResetPath();
            //}
            return;
        }
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (Input.GetTouch(i).tapCount == 2)
                {
                    Ray touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                    if (Physics.Raycast(touchRay, out hit))
                    {
                        player.SetDestination(hit.point);
                    }
                }
            }
        }

    }
}
