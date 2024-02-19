using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowDrag : MonoBehaviour
{
    [SerializeField] private Behaviour rotS;

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            rotS.enabled = false;
        }
    }
}
