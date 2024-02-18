using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotOnDrag : MonoBehaviour
{
    [SerializeField] private GameObject obj1;
    private float rotx;
    float precision = 0.9999f;
    bool rotAble = true;
    float xVal = 0;
    Quaternion targetAngle;

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
        if (rotAble == true)
        {
            xVal = xVal - 120;
            targetAngle = Quaternion.Euler(-1 + xVal, 0, 0);
            rotx = -0.5f;
            rotAble = false;
        }
    }

    public void rotatoU()
    {
        if (rotAble == true)
        {
            xVal = xVal + 120;
            targetAngle = Quaternion.Euler(1 + xVal, 0, 0);
            rotx = 0.5f;
            rotAble = false;
        }
    }
}
