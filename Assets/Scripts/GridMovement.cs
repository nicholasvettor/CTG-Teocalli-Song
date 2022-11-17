using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    public Vector3 SavedMovement = new Vector3(0, 0, 0);
    public float speed = 0.5f;
    public GameObject boxOverLap;

    [ReadOnly]
    private bool move = false; //jeremy is annoying so this is a feautre (I HATE YOU I HATE YOU I HATE YOU)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool run = true;

        int w = 0;
        int s = 0;
        int d = 0;
        int a = 0;

        // gameObject.GetComponent<Collider>)
        if (TimerSystem.tick)
        {
            if (!move)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (!Physics.CheckSphere(transform.position + new Vector3(0, 0, 1), 0.1f))//!Physics.CheckSphere(transform.position + new Vector3(0, 0, 1), 0.1f)overlapSphere(transform.position + new Vector3(0, 0, 1), 0.1f)
                    {
                        w = 1;
                        move = true;
                    }
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (!Physics.CheckSphere(transform.position + new Vector3(0, 0, -1), 0.1f))
                    {//!Physics.CheckSphere(transform.position + new Vector3(0, 0, -1), 0.1f)overlapSphere(transform.position + new Vector3(0, 0, -1), 0.1f)

                        s = 1;
                        move = true;
                    }
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (!Physics.CheckSphere(transform.position + new Vector3(1, 0, 0), 0.1f))
                    {//!Physics.CheckSphere(transform.position + new Vector3(1, 0, 0), 0.1f)overlapSphere(transform.position + new Vector3(1, 0, 0), 0.1f)
                        d = 1;
                        move = true;
                    }
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (!Physics.CheckSphere(transform.position + new Vector3(-1, 0, 0), 0.1f))
                    {//!Physics.CheckSphere(transform.position + new Vector3(-1, 0, 0), 0.1f)overlapSphere(transform.position + new Vector3(-1, 0, 0), 0.1f)
                        a = 1;
                        move = true;
                    }

                }
            }
            
            if (move)
            {
                Vector3 pos = new Vector3(d - a, 0, w - s);
                transform.position += pos;

                if (pos != Vector3.zero)
                {
                    SavedMovement = pos;

                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (!Physics.CheckSphere(transform.position + SavedMovement * 2, 0.2f))//!Physics.CheckSphere(transform.position + SavedMovement * 2, 0.2f)overlapSphere(transform.position + SavedMovement * 2, 0.2f)
                    {
                        transform.position += SavedMovement * 2;

                    }
                }
            }
        }

        if (!TimerSystem.tick)
        {

            move = false;

        }

    }

    private bool overlapSphere(Vector3 pos, float size)
    {

        Collider[] overLap = Physics.OverlapSphere(pos, size);

        if(overLap.Length == 0) { return true; }

        if (overLap.Length == 1)//if something is touching it
        {

            Collider collider = overLap[0];

            if (collider.gameObject.name == "RoomCollider")
            {

                Debug.Log("true");

                return true;

            }
            else
            {

                Debug.Log("false");

                return false;
            }

        }
        else if(overLap.Length < 1)
        {

            Debug.Log("multiple" + overLap.ToString());

            return false; //there are many colliders touching it so dont move

        }

        return true; //nothing is touching the sphere so return true to keep running

    }

}
