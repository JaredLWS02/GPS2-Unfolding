using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotOnDrag : MonoBehaviour
{
    float rot;
    float precision = 0.9999f;
    bool rotAble = true;
    Quaternion targetAngle = Quaternion.Euler(-91, 0, 0);

    void Update()
    {
        transform.Rotate(rot, 0, 0);
        if(rotAble == false)
        {
            if (Mathf.Abs(Quaternion.Dot(this.transform.rotation, targetAngle)) > precision)
            {
                rot = 0;
            }
        }
    }

    public void rotatoD()
    {
        if(rotAble == true)
        {
            rot = -0.5f;
            rotAble = false;
        }
    }


    //Quaternion targetAngle2 = Quaternion.Euler(-1, 0, 0);

    //else if (rotAble == true)
    //{
    //    if (Mathf.Abs(Quaternion.Dot(this.transform.rotation, targetAngle2)) > precision)
    //    {
    //        rot = 0;
    //    }
    //}

    //else if (rotAble == false)
    //{
    //    rot = 0.5f;
    //    rotAble = true;
    //}
}
