using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject puzzle;

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            puzzle.SetActive(true);
        }
    }
}
