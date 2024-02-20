using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
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

    public void RotateObject()
    {
        if (!Islocked)
        {
            objectToDrag.transform.Rotate(Vector3.forward, 90f); // Rotate clockwise by 90 degrees
        }
    }

    public void DragObject()
    {
        if (!Islocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
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
}
