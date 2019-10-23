using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpotLightOnOff : Toggle_Day
{

    // Start is called before the first frame update
    void Start()
    {
        int A = Toggle_Day.GetOneDay();

        if (A == 2)
        {
            GameObject obj = GameObject.Find("SunLight");
            Destroy(obj);
            GameObject obj2 = GameObject.Find("Sphere100");
            obj2.SetActive(false);
            GameObject obj3 = GameObject.Find("Light");
            Destroy(obj3);
        }
        else
        {
        
                GameObject obj4 = GameObject.Find("Spot Light");
                obj4.SetActive(false);
            }
        }
    }

