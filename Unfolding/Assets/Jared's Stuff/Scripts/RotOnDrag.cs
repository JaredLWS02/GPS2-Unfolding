using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotOnDrag : MonoBehaviour
{
    [SerializeField] private GameObject obj1;
    [SerializeField] private float rotationXSpeed;
    public float rotY, rotZ; 
    private float rotx;
    private float precision = 0.9999f;
    private bool rotAble = true;
    private float xVal = 0;
    private Quaternion targetAngle;

    private void Update()
    {
        if(rotAble == false)
        {
            obj1.transform.Rotate(rotx, 0, 0);
            if (Mathf.Abs(Quaternion.Dot(obj1.transform.rotation, targetAngle)) > precision)
            {
                rotx = 0;
                rotAble = true;
            }
        }
    }
    //obj 1
    public void rotatoD()
    {
        Debug.Log("Did rotate");
        if (rotAble == true)
        {
            xVal = xVal - 120;
            targetAngle = Quaternion.Euler(-1 + xVal, rotY, rotZ);
            rotx = -rotationXSpeed;
            rotAble = false;
        }
    }

    public void rotatoU()
    {
        if (rotAble == true)
        {
            xVal = xVal + 120;
            targetAngle = Quaternion.Euler(1 + xVal, rotY, rotZ);
            rotx = rotationXSpeed;
            rotAble = false;
        }
    }
}
