using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

     if(GameObject.Find("SunLight"))
     {
     
        GameObject obj = GameObject.Find("Light");
        Destroy(obj);
     }
    }
}
