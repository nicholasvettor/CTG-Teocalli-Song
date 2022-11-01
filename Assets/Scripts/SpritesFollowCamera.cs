using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesFollowCamera : MonoBehaviour
{

    public Transform MyCameraTransform;
    private Transform MyTransform;
    public bool alignNotLook = true;

    // Start is called before the first frame update
    void Start()
    {
        MyTransform = this.transform;
        MyCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (alignNotLook)
            MyTransform.forward = MyCameraTransform.forward;
        else
            MyTransform.LookAt(MyCameraTransform, Vector3.up);
    }
}
