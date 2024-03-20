using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerReSize : MonoBehaviour
{
    [SerializeField] private GameObject frog;
    [SerializeField] private Camera mainGamePlayCam;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            frog.transform.localScale = new Vector3(0.24f, 0.24f, 0.24f);
            mainGamePlayCam.fieldOfView = 52.0f;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
