using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{

    private bool run = true;
    public int speed = 0;
    private NavMeshAgent agent;

    private bool addNavMesh = false;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(Vector3.zero, out hit, 1000.0f, NavMesh.AllAreas))
        {
            Vector3 result = hit.position;
            addNavMesh = true;
        }
        else
        {
            addNavMesh = false;
        }

        if (addNavMesh)
        {
            agent = gameObject.AddComponent<NavMeshAgent>();
            Debug.Log("added navmeshagent");
        }

    }

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

        speed = 10;

        agent.speed = speed;

        agent.enabled = true;

        Invoke("stopWalking", 0.25f);

    }

    void setRun()
    {
        run = true;
    }

    void stopWalking()
    {
        speed = 0;
    }

}
