using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsystem : MonoBehaviour
{
    bool playerdetection = false;


    // Update is called once per frame
    void Update()
    {
        print("Dialogue Started!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerBody")
        {
            playerdetection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerdetection = false;
    }
}
