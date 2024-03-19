using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamRot : MonoBehaviour
{
    [SerializeField] private CameraRotation camrot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            camrot.enabled = true;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
