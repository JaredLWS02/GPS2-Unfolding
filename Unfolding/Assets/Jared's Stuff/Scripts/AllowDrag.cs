using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowDrag : MonoBehaviour
{
    public Behaviour rotS;

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Entered");
            rotS.enabled = false;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Left");
            rotS.enabled = true;
        }
    }
}
