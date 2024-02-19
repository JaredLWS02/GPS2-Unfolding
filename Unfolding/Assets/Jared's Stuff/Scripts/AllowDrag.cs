using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowDrag : MonoBehaviour
{
    public Behaviour rotS;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.compareTag ("Player"))
        {
            rotS.enabled = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.compareTag("Player"))
        {
            rotS.enabled = true;
        }
    }
}
