using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour
{
    [SerializeField] private NavMeshSurface nav;
    [SerializeField] private NavMeshData data;
    [SerializeField] private NavMeshModifierVolume v;
    // Start is called before the first frame update
    void Start()
    {
        //UpdateMesh();
        InvokeRepeating("UpdateMesh", 2,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateMesh()
    {
        //if(v.area == 1)
        //{
        //    v.area = 0;
        //}
        //else
        //{
        //    v.area = 1;
        //}
        //nav.BuildNavMesh();
        nav.UpdateNavMesh(data);
    }
}
