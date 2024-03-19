using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutSceneEnd : MonoBehaviour
{
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject cutSceneCam;
    [SerializeField] private GameObject cutScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endScene()
    {
        cutSceneCam.SetActive(false);
        mainCam.SetActive(true);
        cutScene.SetActive(false);

    }
}
