using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float limit;
    void Start()
    {
        //offset = transform.position - player.transform.position;

    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;
        transform.position = new Vector3(Mathf.Clamp(smoothedPosition.x,0,limit), Mathf.Clamp(transform.position.y, 0, 0), Mathf.Clamp(transform.position.z, 0, 0));
    }

}
