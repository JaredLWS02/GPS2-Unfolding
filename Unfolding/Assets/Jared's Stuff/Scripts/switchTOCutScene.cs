using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchTOCutScene : MonoBehaviour
{
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject cutSceneCam;
    [SerializeField] private GameObject cutScene;

    // Start is called before the first frame update
    void Start()
    {
        cutScene.SetActive(false);
        cutSceneCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            mainCam.SetActive(false);
            cutSceneCam.SetActive(true);
            cutScene.SetActive(true);
        }
    }
}
