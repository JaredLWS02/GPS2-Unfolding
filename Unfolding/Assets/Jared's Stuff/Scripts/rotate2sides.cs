using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate2sides : MonoBehaviour
{
    [SerializeField] private GameObject objt;
    private float rot;
    private float precision = 0.9999f;
    private bool rotatable = true;
    private float xVal = 0;
    private Quaternion targetAngle;
    [SerializeField] private float rotY, rotZ;

    private void Update()
    {
        if (rotatable == false)
        {
            objt.transform.Rotate(rot, 0, 0);
            if (Mathf.Abs(Quaternion.Dot(objt.transform.rotation, targetAngle)) > precision)
            {
                rot = 0;
                rotatable = true;
            }
        }
    }

    public void rotateD()
    {
        Debug.Log("Did rotate");
        if (rotatable == true)
        {
            xVal = xVal - 180;
            targetAngle = Quaternion.Euler(-1 + xVal, rotY, rotZ);
            rot = -2f;
            rotatable = false;
        }
    }

    public void rotateU()
    {
        Debug.Log("Did rotate");
        if (rotatable == true)
        {
            xVal = xVal + 180;
            targetAngle = Quaternion.Euler(1 + xVal, rotY, rotZ);
            rot = 2f;
            rotatable = false;
        }

    }
}
