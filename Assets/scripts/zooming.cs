using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zooming : MonoBehaviour
{
    public float minFOV = 49f;
    public float maxFOV = 79f;
    public float sensitivity = 2f;
    public float FOV;

    void Update()
    {
        FOV = Camera.main.fieldOfView;
        FOV += (Input.GetAxis("Mouse ScrollWheel") * sensitivity) * -1;
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
        Camera.main.fieldOfView = FOV;
    }
}
