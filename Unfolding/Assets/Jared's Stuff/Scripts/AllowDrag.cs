using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowDrag : MonoBehaviour
{
    [SerializeField] private Behaviour rotS;

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            rotS.enabled = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            rotS.enabled = true;
        }
    }
}
