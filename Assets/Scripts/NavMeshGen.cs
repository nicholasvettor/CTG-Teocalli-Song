using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class NavMeshGen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         //this entire class is for 2 lines this isn't even nesscessary

        NavMeshBuilder.ClearAllNavMeshes();
        NavMeshBuilder.BuildNavMesh();

        Debug.Log("Generated NavMesh");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
