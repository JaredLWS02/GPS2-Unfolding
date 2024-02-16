using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotOnDrag : MonoBehaviour
{
    float rotx,roty,rotz;
    float precision = 0.9999f;
    bool rotAble = true;
    float xVal = 0;
    float yVal = 0;
    Quaternion targetAngle;

    void Update()
    {
        transform.Rotate(rotx, 0, 0);
        if(rotAble == false)
        {
            if (Mathf.Abs(Quaternion.Dot(this.transform.rotation, targetAngle)) > precision)
            {
                rotx = 0;
                rotAble = true;
                //roty = 0;
                //rotz = 0;
            }
        }
    }

    public void rotatoD()
    {
        if (rotAble == true)
        {
            xVal = xVal - 90;
            targetAngle = Quaternion.Euler(-1+xVal, 0, 0);
            rotx = -0.5f;
            rotAble = false;
        }
    }

    public void rotatoU()
    {
        if (rotAble == true)
        {
            xVal = xVal + 90;
            targetAngle = Quaternion.Euler(1 + xVal, 0, 0);
            rotx = 0.5f;
            rotAble = false;
        }
    }

    //public void rotatoZ()
    //{
    //    if (rotAble == true)
    //    {
    //        rotz = -0.5f;
    //        rotAble = false;
    //    }
    //}
}
