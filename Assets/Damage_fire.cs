using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_fire : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (TimerSystem.tick)
            {

                foreach(BasicEnemy enemy in GameObject.FindObjectsOfType<BasicEnemy>())
                {
                    Debug.Log("woujnadiawuj: " + enemy.name);
                    Vector3 vector3 = (gameObject.transform.position - enemy.transform.position);

                    if (vector3.magnitude <= 5)
                    {

                        enemy.kill();

                        Debug.Log("KIlled " + enemy.name);

                    }

                }

            }
        }
    }

    public bool overlapSphere(Vector3 pos, float size)
    {

        Collider[] overLap = Physics.OverlapSphere(pos, size);

        if (overLap.Length == 0) { return true; }

        if (overLap.Length == 1)//if something is touching it
        {

            Collider collider = overLap[0];

            if (collider.gameObject.GetComponent<BasicEnemy>())
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
        else if (overLap.Length < 1)
        {

            Debug.Log("multiple" + overLap.ToString());

            return false; //there are many colliders touching it so dont move

        }

        return true; //nothing is touching the sphere so return true to keep running

    }

}
