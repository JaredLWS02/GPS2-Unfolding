using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutSceneEnd : MonoBehaviour
{
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject cutSceneCam;
    [SerializeField] private GameObject cutScene;
    [SerializeField] private Animator anim1;
    [SerializeField] private Animator anim2;
    [SerializeField] private Animator anim3;

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
        anim1.enabled = false;
        anim2.enabled = false;
        anim3.enabled = false;
        cutSceneCam.SetActive(false);
        mainCam.SetActive(true);
        cutScene.SetActive(false);

    }
}
