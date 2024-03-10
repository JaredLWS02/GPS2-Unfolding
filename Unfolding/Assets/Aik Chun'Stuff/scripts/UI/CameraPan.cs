using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [SerializeField] private  GameObject cam;
    [SerializeField] private Vector3 endpos;
    [SerializeField] private float speed;

    private Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = cam.transform.position;   
    }

    public void Settings()
    {
        LeanTween.moveLocalX(cam,endpos.x, speed);
    }

    public void MainMenu()
    {
        LeanTween.moveLocalX(cam, startpos.x, speed);
    }
}
