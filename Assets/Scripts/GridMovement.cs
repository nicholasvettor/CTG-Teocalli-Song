using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) {
            if (!Physics.CheckSphere(transform.position + new Vector3(0,0,1), 0.1f)) {
                transform.position += new Vector3(0, 0, 1);
            }        
            
            
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (!Physics.CheckSphere(transform.position + new Vector3(0, 0, -1), 0.1f)){

                transform.position += new Vector3(0, 0, -1);
            }
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            if (!Physics.CheckSphere(transform.position + new Vector3(1, 0, 0), 0.1f)){
                transform.position += new Vector3(1, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!Physics.CheckSphere(transform.position + new Vector3(-1, 0, 0), 0.1f)){
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        






    }
}
