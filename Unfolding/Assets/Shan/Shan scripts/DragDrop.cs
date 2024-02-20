using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class DragDrop : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject ObjectDragToPosition;
    public float Dropdistance;
    public bool Islocked;

    private Vector2 objectInitPos;
    private Quaternion objectInitRot;

    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = objectToDrag.transform.position;
        objectInitRot = objectToDrag.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Islocked)
        {
            HandleTouchInput();
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Only handle the first touch for simplicity

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    RotateObject();
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    DragObject(touch.position);
                    break;
                case TouchPhase.Ended:
                    DropObject();
                    break;
            }
        }
    }

    private void RotateObject()
    {
        objectToDrag.transform.Rotate(Vector3.forward, 90f); // Rotate clockwise by 90 degrees
    }

    private void DragObject(Vector2 touchPosition)
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 10));
        objectToDrag.transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

    private void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPosition.transform.position);
        if (Distance < Dropdistance && IsCorrectRotation())
        {
            Islocked = true;
            objectToDrag.transform.position = ObjectDragToPosition.transform.position;
        }
        else
        {
            objectToDrag.transform.position = objectInitPos;
            objectToDrag.transform.rotation = objectInitRot;
        }
    }

    private bool IsCorrectRotation()
    {
        // Check if the object's rotation is close to the desired rotation (within a small tolerance)
        return Quaternion.Angle(objectToDrag.transform.rotation, ObjectDragToPosition.transform.rotation) < 1f;
    }
}*/
public class DragDrop : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject ObjectDragToPosition;
    public float Dropdistance;
    public bool islocked = false;

    private Vector2 objectInitPos;
    private Quaternion objectInitRot;


    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = objectToDrag.transform.position;
        objectInitRot = objectToDrag.transform.rotation;
    }

    public void RotateObject()
    {
        if (!islocked)
        {
            objectToDrag.transform.Rotate(Vector3.forward, 90f); // Rotate clockwise by 90 degrees
        }
    }

    public void DragObject()
    {
        if (!islocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPosition.transform.position);
        if (Distance < Dropdistance && IsCorrectRotation())
        {
            LockObject();
        }
        else
        {
            ResetObject();
        }
    }

    private bool IsCorrectRotation()
    {
        // Check if the object's rotation is close to the desired rotation (within a small tolerance)
        return Quaternion.Angle(objectToDrag.transform.rotation, ObjectDragToPosition.transform.rotation) < 1f;
    }

    public void LockObject()
    {
        islocked = true;
        objectToDrag.transform.position = ObjectDragToPosition.transform.position;
    }

    public void UnlockObject()
    {
        islocked = false;
    }

    private void ResetObject()
    {
        objectToDrag.transform.position = objectInitPos;
        objectToDrag.transform.rotation = objectInitRot;
    }
}

