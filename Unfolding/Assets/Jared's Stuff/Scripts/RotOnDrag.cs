using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotOnDrag : MonoBehaviour
{
    float rotx,roty,rotz;
    float precision = 0.9999f;
    bool rotAble = true;
    Quaternion targetAngle = Quaternion.Euler(-91, 0, 0);

    void Update()
    {
        transform.Rotate(rotx, 0, 0);
        if(rotAble == false)
        {
            if (Mathf.Abs(Quaternion.Dot(this.transform.rotation, targetAngle)) > precision)
            {
                rotx = 0;
                roty = 0;
                rotz = 0;
            }
        }
    }

    public void rotatoD()
    {
        if(rotAble == true)
        {
            rotx = -0.5f;
            rotAble = false;
        }
    }

    public void rotatoY()
    {
        if (rotAble == true)
        {
            roty = -0.5f;
            rotAble = false;
        }
    }

    public void rotatoZ()
    {
        if (rotAble == true)
        {
            rotz = -0.5f;
            rotAble = false;
        }
    }
}
