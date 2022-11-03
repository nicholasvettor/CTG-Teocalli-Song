using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{

    public List<GameObject> rooms = new List<GameObject>();

    [ReadOnly]
    public List<GameObject> generatedRooms = new List<GameObject>();

    public int commonRoomSize = 11;

    [ReadOnly]
    public int distance = 11;

    public int timesRun = 10;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < timesRun; i++)
        {

            int randomRoom = Random.Range(0, rooms.Count);

            GameObject room = GameObject.Instantiate(rooms[randomRoom]);

            room.transform.Translate(0,0,distance);

            generatedRooms.Add(room);

            distance += commonRoomSize;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
