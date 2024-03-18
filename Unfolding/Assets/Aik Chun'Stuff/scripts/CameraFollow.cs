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
        if(gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            if (GameEventManager.isTouchPage == false)
            {
                Vector3 desiredPosition = player.transform.position + offset;
                GetComponentInChildren<Camera>().fieldOfView = 34;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                //transform.position = smoothedPosition;
                if (transform.position.z <= -10.55f)
                {
                    transform.position = new Vector3(-16.2f, 0.0f, 0.0f);
                }
                else
                {
                    transform.position = new Vector3(Mathf.Clamp(smoothedPosition.x, -16.2f, limit), 0.0f, transform.position.z);
                }
            }
            else
            {
                Vector3 desiredPosition = new Vector3(2.13f, 7.7f, -10.55f);
                GetComponentInChildren<Camera>().fieldOfView = 60;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                //transform.position = smoothedPosition;
                transform.position = desiredPosition;
            }

        }
    }

}
