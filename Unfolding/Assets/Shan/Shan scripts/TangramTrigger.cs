using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangramTrigger : MonoBehaviour
{
    public Canvas tangramCanvas;
    public GameObject objectToDisable;
    public List<GameObject> tangramPieces;
    public Transform respawnPoint;

    private bool puzzleComplete = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !puzzleComplete)
        {
            // Activate the tangram canvas
            tangramCanvas.gameObject.SetActive(true);
            CheckPuzzleCompletion();
        }
    }
    private void CheckPuzzleCompletion()
    {
        foreach (GameObject piece in tangramPieces)
        {
            if (!piece.GetComponent<DragDrop>().Islocked)
            {
                return; // Exit function if any piece is not locked
            }
        }
        // If all pieces are locked, mark puzzle as complete
        SetPuzzleComplete(true);
    }

    public void SetPuzzleComplete(bool complete)
    {
        puzzleComplete = complete;

        // If puzzle is complete, deactivate the canvas and disable the object
        if (complete)
        {
            tangramCanvas.gameObject.SetActive(false);
            Debug.Log("Tangram canvas disabled.");
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
            }
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        // Move the player to the respawn point
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && respawnPoint != null)
        {
            player.transform.position = respawnPoint.position;
            player.transform.rotation = respawnPoint.rotation;
        }
    }
}
