using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject ObjectDragToPosition;

    public float Dropdistance;

    public bool Islocked;

    Vector2 objectInitPos;

    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = objectToDrag.transform.position;
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
        if (Distance < Dropdistance)
        {
            Islocked = true;
            objectToDrag.transform.position = ObjectDragToPosition.transform.position; 
        }
        else
        {
            objectToDrag.transform.position = objectInitPos;
        }
    }
}
