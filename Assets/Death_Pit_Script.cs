using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Pit_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {




    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerStat>().CurrentHealth = 0;
            Debug.Log("Player died in pit");
        }
    }

}
