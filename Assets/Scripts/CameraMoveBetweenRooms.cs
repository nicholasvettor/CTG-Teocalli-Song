using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveBetweenRooms : MonoBehaviour
{

    public Transform cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0, 0, 11);
    }

    // Update is called once per frame
    void Update()
    {
        
        

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

                    //Quaternion rot = cameraPos.rotation;//sets rotation to variable

                    //cameraPos.rotation.Set(0, 0, 0, 0);//resets rotation

                    cameraPos.position = new Vector3(cameraPos.position.x, cameraPos.position.y, child.position.z);

                    Debug.Log(cameraPos.position.x + ", " + cameraPos.position.y + ", " + child.position.z);

                    //cameraPos.rotation = rot;//set cameras rotation back
                }

            }
        }
    }


}
