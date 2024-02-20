using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    public Camera mainCamera;
    public Camera npcCamera;
    public GameObject playerObject;
    public Collider playerCollider; // Collider to disable player detection
    public Transform respawnPoint; // New spawn point for the player

    private bool playerDetected;

    //Detect trigger with player
    private void OnTriggerEnter(Collider collision)
    {
        //if we triggered the player enable player detected and shhow indicator
        if (collision.tag == "Player")
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
            // Activate NPC camera
            npcCamera.gameObject.SetActive(true);
            // Deactivate main camera
            mainCamera.gameObject.SetActive(false);
            // Start dialogue immediately
            dialogueScript.StartDialogue();

            // Disable player object and its collider
            playerObject.SetActive(false);
            playerCollider.enabled = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //if we lost trigger with the player disable player detected and hide indicator
        if (collision.tag == "Player")
        {
            enablePlayer();
        }
    }

    public void enablePlayer()
    {
        playerDetected = false;
        dialogueScript.ToggleIndicator(playerDetected);
        //dialogueScript.EndDialogue();
        // Activate main camera
        mainCamera.gameObject.SetActive(true);
        // Deactivate NPC camera
        npcCamera.gameObject.SetActive(false);

        // Re-enable player object and its collider
        playerObject.SetActive(true);
        playerCollider.enabled = true;

        // Respawn player at the new spawn point
        playerObject.transform.position = respawnPoint.position;
    }
    //While detected if we interact start the dialogue
    /*private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }
    }*/

}
