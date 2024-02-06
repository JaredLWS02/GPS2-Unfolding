using System;
using System.Collections;
using UnityEngine;

public class CemeraRotation : MonoBehaviour
{
    private Vector2 SwipeStartPos;
    private Vector2 SwipeEndPos;
    private bool rightSwipe = false;
    private bool isRotating = false;
    private float startRotation;
    private float EndRotation;

    [SerializeField] private float MinSwipeDistance;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float RotationAngle;
    [SerializeField] private PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.eulerAngles.y;
    }

    private void Update()
    {

    }
    private void LateUpdate()
    {
        if (!isRotating && !GameEventManager.isTouchObject)
        {
            pm.isRotate = false;
            if (Input.touchCount > 0)
            {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        startRotation = transform.eulerAngles.y;
                        SwipeStartPos = Input.GetTouch(0).position;
                    }

                    if(Input.touchCount < 2)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        SwipeEndPos = Input.GetTouch(0).position;
                        float swipedistance = SwipeEndPos.magnitude - SwipeStartPos.magnitude;

                        if (swipedistance > MinSwipeDistance || swipedistance < -MinSwipeDistance)
                        {
                            isRotating = true;

                            if (swipedistance > 0)
                            {
                                StartCoroutine(RotateCamRight());
                            }
                            else
                            {
                                StartCoroutine(RotateCamLeft());
                            }
                        }

                    }

                }
            }
        }
        else
        {
            pm.isRotate = true;
        }
    }

    private IEnumerator RotateCamRight()
    {
        EndRotation = startRotation + RotationAngle;
        while(isRotating)
        {
            transform.Rotate(0, (float)(RotationSpeed * Time.deltaTime), 0);
            if (transform.eulerAngles.y >= EndRotation - 10)
            {
                if (EndRotation >= 360)
                {
                    startRotation = 0;
                    EndRotation = 0;
                }
                transform.rotation = Quaternion.Euler(0, EndRotation, 0);
                isRotating = false;
            }
            yield return null;
        }
    }

    private IEnumerator RotateCamLeft()
    {
        if (startRotation == 0)
        {
            EndRotation = 360 + (-RotationAngle);
        }
        else
        {
            EndRotation = startRotation - RotationAngle;
        }

        while(isRotating)
        {
            transform.Rotate(0, (float)(-RotationSpeed * Time.deltaTime), 0);
            if (transform.eulerAngles.y <= EndRotation + 10)
            {
                if (EndRotation <= -360)
                {
                    startRotation = 0;
                    EndRotation = 0;
                }
                transform.rotation = Quaternion.Euler(0, EndRotation, 0);
                isRotating = false;
            }
            yield return null;
        }

    }
}
