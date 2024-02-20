using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangramTrigger : MonoBehaviour
{
    public Canvas tangramCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the tangram canvas
            tangramCanvas.gameObject.SetActive(true);
        }
    }

}
