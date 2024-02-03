using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotOnDrag : MonoBehaviour
{
    private Vector3 Rot;
    private float speed = 10.0f;

    private void update()
    {
        Rot.transform.Rotate(Rot * -speed * Time.deltaTime);
        if(Rot.y <= -90)
        {

        }
    }
}
