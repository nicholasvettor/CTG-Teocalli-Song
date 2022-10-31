using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    public Vector3 SavedMovement = new Vector3(0, 0, 0);
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int w = 0;
        int s = 0;
        int d = 0;
        int a = 0;

        if(Input.GetKeyDown(KeyCode.W)) {
            if (!Physics.CheckSphere(transform.position + new Vector3(0, 0, 1), 0.1f))
            {
                w = 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (!Physics.CheckSphere(transform.position + new Vector3(0, 0, -1), 0.1f)){

                s = 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            if (!Physics.CheckSphere(transform.position + new Vector3(1, 0, 0), 0.1f)){
                a = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!Physics.CheckSphere(transform.position + new Vector3(-1, 0, 0), 0.1f)){
                d = 1;
            }

        }


        Vector3 pos = new Vector3(a - d, 0, w - s);
        transform.position += pos;


        if (pos != Vector3.zero)
        {
            SavedMovement = pos;
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Physics.CheckSphere(transform.position + SavedMovement * 2, 0.2f))
            {
                transform.position += SavedMovement * 2;
                
            }
        }






    }
}
