using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowRoom : MonoBehaviour
{
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        material.color = Color.HSVToRGB(.34f, .84f, .67f);
    }

    // Update is called once per frame
    void Update()
    {
        // Assign HSV values to float h, s & v. (Since material.color is stored in RGB)
        float h, s, v;
        Color.RGBToHSV(material.color, out h, out s, out v);

        // Use HSV values to increase H in HSVToRGB. It looks like putting a value greater than 1 will round % 1 it
        material.color = Color.HSVToRGB(h + Time.deltaTime * .25f, s, v);
    }
}
