using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        // Get the camera's position
        Transform cameraTransform = Camera.main.transform;

        // Make the canvas face the camera
        transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward,
                          cameraTransform.rotation * Vector3.up);
    }
}
