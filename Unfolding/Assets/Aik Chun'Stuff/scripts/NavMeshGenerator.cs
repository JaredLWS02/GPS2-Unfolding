using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour
{
    [SerializeField] private NavMeshSurface nav;

    private bool doOnce;

    //[SerializeField] private NavMeshData data;
    //[SerializeField] private NavMeshModifierVolume v;
    //[SerializeField] private GameObject obstacles;
    // Start is called before the first frame update
    void Awake()
    {
        doOnce = true;

        if(nav != null)
        {
            nav.UpdateNavMesh(nav.navMeshData);
        }
        else
        {
            Debug.Log("You forgot to reference the navmesh. But it not big deal");
        }
    }

    private void Update()
    {
        if (PageFlip.flipped == true && doOnce == false)
        {
            nav.UpdateNavMesh(nav.navMeshData);
            doOnce = true;
        }
        else if(PageFlip.flipped == false && doOnce == true) 
        {
            doOnce = false;
        }
    }
    //// Update is called once per frame
    //void Update()
    //{

    //}

    //void UpdateMesh()
    //{
    //    if (v.area == 1)
    //    {
    //        obstacles.SetActive(false);
    //        v.area = 0;
    //    }
    //    else
    //    {
    //        obstacles.SetActive(true);
    //        v.area = 1;
    //    }
    //    //nav.BuildNavMesh();
    //    nav.UpdateNavMesh(data);
    //}
}
