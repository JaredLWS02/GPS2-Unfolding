using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour
{
    [SerializeField] private NavMeshSurface nav;
    //[SerializeField] private NavMeshData data;
    //[SerializeField] private NavMeshModifierVolume v;
    //[SerializeField] private GameObject obstacles;
    // Start is called before the first frame update
    void Awake()
    {
        if(nav != null)
        {
            nav.UpdateNavMesh(nav.navMeshData);
        }
        else
        {
            Debug.Log("You forgot to reference the navmesh. But it not big deal");
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
