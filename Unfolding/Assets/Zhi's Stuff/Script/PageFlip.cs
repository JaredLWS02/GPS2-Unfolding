using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlip : MonoBehaviour
{
    [Tooltip("The higher, the more you need to swipe")]
    public float flipSensitivity = 5000f;

    private Ray ray;
    private RaycastHit hit;

    private Vector2 startPos, pos;

    private Touch touch;
    private Animator anim;

    private bool clicked;

    private float frame; 

    private void Start()
    {
        frame = 0;
        anim = GetComponentInParent<Animator>();
        anim.speed = 0;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider)
                {
                    startPos = Input.touches[0].position;
                    clicked = true;
                    GameEventManager.isTouchObject = true;
                }
            }
        }
        else if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            GameEventManager.isTouchObject = false;
            clicked = false;
        }

        if (clicked)
        {
            touch = Input.GetTouch(0);

            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
            {
                startPos = touch.position - touch.deltaPosition;
                pos = touch.position - startPos;

                frame += (-pos.x) / flipSensitivity;
                Debug.Log(frame);
                anim.Play("IFlip", 0, frame);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.touchCount == 0)
        {
            if (frame > 0.5)
            {
                frame += 0.01f;
                anim.Play("IFlip", 0, frame);
            }
            else if (frame < 0.5)
            {
                frame -= 0.01f;
                anim.Play("IFlip", 0, frame);
            }

            // My favourite line in programming
            if (frame < 0)
                frame = 0;
            else if (frame > 1)
                frame = 1;
        }
        // BUGS I FOUND
        /* - Loading and deloading assets in. I have to find a way to instance stuff so that that pages can be renewed on the other side
         * - Yes, I know, the mouse doesn't work, bohoo.
         */
    }
}
