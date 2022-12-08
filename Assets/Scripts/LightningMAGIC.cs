using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMAGIC : MonoBehaviour
{

    public SpriteRenderer fire_ring;

    public GameObject obj;

    public bool run;

    bool magic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerSystem.tick)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {

                Invoke("setRun", 0.99f);

                

                //obj.transform.rotation = obj.transform.rotation * Quaternion.Euler(obj.transform.eulerAngles.x, Mathf.SmoothStep(obj.transform.rotation.y, 0, Time.deltaTime * 2),transform.eulerAngles.z);

                magic = true;

                Debug.Log("awlijdoai: " + Mathf.Lerp(obj.transform.rotation.y, 0, Time.deltaTime * 2));

            }
        }
        else


        if (magic)
        {
            var color = fire_ring.color;

            color.a = Mathf.Lerp(color.a, 255, Time.deltaTime);

            fire_ring.color = color;

            Debug.Log("awuhdfiwuafhiwauhfaiuwhfiuawhfawiuhf");
            obj.transform.eulerAngles = new Vector3(90, Mathf.Lerp(obj.transform.rotation.y, 360, Time.deltaTime) * 100, 0);

            
        }
    }

    void setRun()
    {
        run = true;
        magic = false;
        obj.transform.eulerAngles = new Vector3(90, 0, 0);

        var color = fire_ring.color;

        color.a = 0;

        fire_ring.color = color;
    }
}
