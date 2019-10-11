using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Toggle_Day : MonoBehaviour
{

    public void ChageMornning()
    {
        Debug.Log("Toggle switched");

        transform.eulerAngles = new Vector3(90, 0, 0);

    }

    public void ChageAfternoon()
    {
        Debug.Log("Toggle switched");

        transform.eulerAngles = new Vector3(0, 0, 0);

    }

    public void ChageNight()
    {
        Debug.Log("Toggle switched");
        transform.eulerAngles = new Vector3(-90, 0, 0);
    }

}
