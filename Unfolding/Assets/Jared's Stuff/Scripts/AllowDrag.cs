using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowDrag : MonoBehaviour
{
    [SerializeField] private Behaviour rotS;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            rotS.enabled = false;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            rotS.enabled = true;
        }
    }
}
