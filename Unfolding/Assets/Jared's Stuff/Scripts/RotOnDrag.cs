using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotOnDrag : MonoBehaviour
{
    float rot;
    float precision = 0.9999f;
    Quaternion targetAngle = Quaternion.Euler(-91, 0, 0);


    void Update()
    {
        transform.Rotate(rot, 0, 0);
        if (Mathf.Abs(Quaternion.Dot(this.transform.rotation, targetAngle)) > precision)
        {
            rot = 0;
        }
    }

    public void rotatoD()
    {
        rot = -0.5f;
    }
}
