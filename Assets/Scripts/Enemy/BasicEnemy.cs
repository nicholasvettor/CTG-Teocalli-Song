using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{

    private bool run = true;
    public int speed = 0;

    // Update is called once per frame
    void Update()
    {
        //agent.destination = GameObject.Find("Player").transform.position;

        if (TimerSystem.tick)
        {
            if (run)
            {
                run = false;

                bool look = canSee(GameObject.Find("Player"));

                if (look)
                {

                    moveToPlayer(GameObject.Find("Player"));

                }
            }
            else
            {
                Invoke("setRun", 0.5f);
            }


        }
    }

    bool canSee(GameObject lookAt)
    {

        gameObject.transform.LookAt(lookAt.transform);

        Ray ray = new Ray();

        ray.origin = gameObject.transform.position;

        ray.direction = gameObject.transform.forward;

        RaycastHit hit;
        // Casts the ray and get the first game object hit 
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "Player")
            {
                Debug.Log("Hit the player");
                return true;
            }
            else
            {
                Debug.Log("Did'nt the player");
            }

        }

        return false;

    }

    void moveToPlayer(GameObject player)
    {

        Vector3 vector = gameObject.transform.position - player.transform.position;

        float distance = vector.magnitude;

        if(distance <= 1)
        {

            player.GetComponent<PlayerStat>().CurrentHealth -= 34;

        }
        else
        {
            transform.position += transform.forward;
        }

    }

    void setRun()
    {
        run = true;
    }

    public void kill()
    {
        Destroy(gameObject);
    }

}
