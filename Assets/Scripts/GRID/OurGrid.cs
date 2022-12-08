using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurGrid : MonoBehaviour
{
    public Pathfinder path;
    public Transform playerGO;

    public GameObject roomFloor;

    public List<GameObject> enemies;

    public bool Run;
    
    // Start is called before the first frame update
    void Start()
    {

        playerGO = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

        path.GoalNodePosition = playerPosToGoalPos(playerGO.position);

        Debug.Log(path.GoalNodePosition.x + path.GoalNodePosition.y);

        List<GameObject> pathList = new List<GameObject>();

        if (TimerSystem.tick)
        {

            if (Run)
            {

                GameObject go = new GameObject("EEE");
                go.transform.position = path.GoalNodePosition;

                Run = false;

                if (path.path != null)
                {
                    List<Node> paths = path.path;

                    foreach (GameObject enemy in enemies)
                    {

                        enemy.transform.position = paths[0].Position;

                        paths.RemoveAt(0);

                    }
                }

                Invoke("NoRunny", 0.5f);
            }
        }

    }
    
    void NoRunny()
    {
        Run = true;
    }

    Vector2 playerPosToGoalPos(Vector3 player)
    {

        Vector3 vector3 = (roomFloor.transform.position - player);

        Vector2 pos = new Vector2(vector3.x, vector3.z);

        pos.x = Mathf.RoundToInt(pos.x);
        pos.y = Mathf.RoundToInt(pos.y);

        foreach(Node node in path.path)
        {
            if((new Vector3(node.Position.x, 0, node.Position.y) - player).magnitude <= 1)
            {

            }
        }

        return pos;
    }
}
