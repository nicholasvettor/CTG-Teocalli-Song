using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{

    public static bool tick;

    public Camera camera;

    public int normalFov;

    public int backFov;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("runTick", 0.01f, 1.0f);

    }

    private void runTick()
    {
        tick = true;

        Invoke("noRunTick", 0.25f);

        camera.fieldOfView = backFov;

        Debug.Log("waojhfgsieyuhq3wiyegheiduehbivusnigbufahs");

    }

    private void noRunTick()
    {

        camera.fieldOfView = normalFov;

        tick = false;

    }

    public static bool getTick()
    {

        return tick;

    }

    /*private void Update()
    {
        if (tick)
        {

            camera.fieldOfView = Mathf.SmoothStep(camera.fieldOfView, normalFov,Time.deltaTime);//no worky

        }
    }*/

}
