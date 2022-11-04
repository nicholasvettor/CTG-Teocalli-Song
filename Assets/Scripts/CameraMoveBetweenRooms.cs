using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveBetweenRooms : MonoBehaviour
{

    public Transform cameraPos;

    private Vector3 childPos;
    
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotation = transform.rotation;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.Translate(0, 0, 11);
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {

          if(childPos != null)
        {

            cameraPos.position = Vector3.Lerp(cameraPos.position, childPos, 1 * Time.deltaTime);

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("NONWODAWNDWADAW");

        if (other.gameObject.name == "RoomCollider")
        {
            GameObject room = other.gameObject.transform.parent.gameObject;

            Debug.Log("Room: " + room.name);

            foreach (Transform child in room.GetComponentsInChildren<Transform>())
            {

                if (child.gameObject.name == "CameraPos")
                {
                    Debug.Log("working");

                    childPos = child.transform.position;

                    //cameraPos.position = new Vector3(cameraPos.position.x, cameraPos.position.y, child.position.z);

                    Debug.Log(cameraPos.position.x + ", " + cameraPos.position.y + ", " + child.position.z);
                }

            }
        }
    }


}