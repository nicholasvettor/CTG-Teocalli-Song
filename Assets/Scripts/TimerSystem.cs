using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour
{

    public static bool tick;

    public Camera camera;

    public int normalFov;

    public int backFov;

    public List<Sprite> timerSprites;

    public Image timerImage;

    private int Image;

    private bool run;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("runTick", 0.5f, 1.0f);

    }

    private void runTick()
    {
        tick = true;

        Invoke("noRunTick", 0.25f);

        camera.fieldOfView = backFov;

        Debug.Log("FOV Updated");

        Invoke("SetSpriteImage", 0.079f);

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

    void Update()
    {
        
    }

    public void SetSpriteImage()
    {

        if(Image >= timerSprites.Count)
        {
            Image = 0;
            return;
        }
        else
        {
            Debug.Log(Image);

            timerImage.sprite = timerSprites[Image++];

            Invoke("SetSpriteImage", 0.079f);//
        }
        

    }

}
