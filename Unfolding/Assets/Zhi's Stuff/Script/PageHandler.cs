using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PageHandler : MonoBehaviour
{
    //public NavMeshData navMesh1;

    public GameObject frog;

    private Transform t;
    private bool doOnce;

    private Ray ray;
    private RaycastHit hit;

    private void Start()
    {
        doOnce = false;
    }

    public void Update()
    {
        // Do raycast to selected page to select which page
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.touches[0].position != null)
            {
                ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

                if (Physics.Raycast(ray, out hit))
                {
                    if (PageFlip.flipped == true && doOnce == false && GameEventManager.selectedPage == hit.collider.name)
                    {
                        // find in child which object to set the position to
                        t = hit.transform.Find("Spawn Point").GetComponent<Transform>();
                        frog.transform.position = t.position;
                        doOnce = true;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            frog.transform.position = t.position;
        }

        if (PageFlip.flipped == false)
        {
            doOnce = false;
            if (t != null)
                frog.transform.position = t.position;
        }

        if (hit.transform != null)
            t = hit.transform.Find("Spawn Point").GetComponent<Transform>();
    }


    public void NavMap1()
    {
        return;
    }
}
