using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchTOCutScene : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera cutSceneCam;
    [SerializeField] private GameObject cutScene;

    // Start is called before the first frame update
    void Start()
    {
        cutScene.SetActive(false);
        cutSceneCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            mainCam.enabled = false;
            cutSceneCam.enabled = true;
            cutScene.SetActive(true);
        }
    }
}
