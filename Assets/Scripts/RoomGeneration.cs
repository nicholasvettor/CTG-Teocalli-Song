using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.Collections;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{

    public List<GameObject> rooms = new List<GameObject>();

    [ReadOnly]
    public List<GameObject> generatedRooms = new List<GameObject>();

    public List<int> finishedList = new List<int>();

    public List<int> uniqueRooms = new List<int>();

    public int commonRoomSize = 17;

    [ReadOnly]
    public int distance = 34;

    public int timesRun = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < timesRun; i++)
        {
            uniqueRooms.Add(i);
        }

        for (int i = 0; i < timesRun; i++)
        {
            int ranNum = uniqueRooms[Random.Range(0, uniqueRooms.Count)];
            finishedList.Add(ranNum);
            uniqueRooms.Remove(ranNum);
        }



        List<GameObject> uniqueRoomGen = new List<GameObject>();

        foreach (int num in finishedList)
        {

            GameObject room = GameObject.Instantiate(rooms[num]);

            room.transform.position = new Vector3(20, room.transform.position.y, room.transform.position.z);

            room.transform.Translate(0, 0, distance);

            generatedRooms.Add(room);

            distance += commonRoomSize;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
