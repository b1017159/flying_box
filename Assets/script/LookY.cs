using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float y_sensitivity = 3f;

    void Update()
    {
        float x_mouse = Input.GetAxis("Mouse X");
        float y_mouse = Input.GetAxis("Mouse Y");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += x_mouse * y_sensitivity;
        newRotation.x += y_mouse * y_sensitivity;
        transform.localEulerAngles = newRotation;
    }
}