using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PageFlip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DebuggingText;
    [SerializeField] private float sensitivity = 5000;
    [SerializeField] private Animator nextPageAnimator;
    [SerializeField] private Animator prevPageAnimator;

    public bool clicked;

    private Ray ray;
    private RaycastHit hit;

    private Vector2 startPos, pos;
    private float frame;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        frame = 0;
    }

    void Update()
    {
        DebuggingText.text = GameEventManager.selectedPage;
        GetTouch();
        if (hit.collider != null)
        {
            Flipping();
        }
    }

    private void GetTouch()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider)
                {
                    GameEventManager.selectedPage = hit.collider.name;
                    clicked = true;
                    startPos = Input.touches[0].position;
                    GameEventManager.isTouchObject = true;

                }
            }
        }
        else if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            GameEventManager.isTouchObject = false;
            clicked = false;
        }
    }
    private void Flipping()
    {
        Touch touch;

        #region Flipping Base

        if (clicked && Input.touchCount> 0 && hit.collider.name == GameEventManager.selectedPage)
        {
            touch = Input.GetTouch(0);
            if (hit.collider.gameObject.name == this.name)
            {
                if (Input.touches[0].phase == TouchPhase.Moved)
                {
                    pos = touch.position - startPos;
                    frame += (-pos.x) / sensitivity;
                    anim.Play("IFlip", 0, frame);
                    if (nextPageAnimator != null)
                        nextPageAnimator.Play("IOpen", 0, frame);
                    if (prevPageAnimator != null)
                        prevPageAnimator.Play("IOpen", 0, frame);
                }
            }
        }
        else
        {
            if (frame > 0.5)
            {
                frame += 0.01f;
            }
            else if (frame < 0.5)
            {
                frame -= 0.01f;
            }

            if (hit.collider.name == GameEventManager.selectedPage)
            {
                anim.Play("IFlip", 0, frame);

                if (nextPageAnimator != null)
                    nextPageAnimator.Play("IOpen", 0, frame);
                if (prevPageAnimator != null)
                    prevPageAnimator.Play("IOpen", 0, frame);
            }

            clicked = false;
        }
        #endregion

        #region Limit Flip
        if (frame >= 1)
        {
            frame = 1;
        }
        else if (frame <= 0)
        {
            frame = 0;
        }
        #endregion
    }

    // BUGS I FOUND
    /* - When flipping the other way, it will instantly snap to the end, probably due to how it is coded in positional based, rather than like an additive type of way. I'm not sure why it won't let me but
     * I'll just have make do with this for now.
     *  - Loading and deloading assets in. I have to find a way to instance stuff so that that pages can be renewed on the other side
     *   - Yes, I know, the mouse doesn't work, bohoo.
     */
}
