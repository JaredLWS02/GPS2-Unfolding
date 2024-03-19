using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchTOCutScene : MonoBehaviour
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
            anim1.enabled = true;
            anim2.enabled = true; 
            anim3.enabled = true;
            mainCam.SetActive(false);
            cutSceneCam.SetActive(true);
            cutScene.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
