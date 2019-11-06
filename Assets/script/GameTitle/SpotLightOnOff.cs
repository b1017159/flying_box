﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpotLightOnOff : Toggle_Day
{


    // Start is called before the first frame update
    void Update()
    {
        int A = Toggle_Day.GetOneDay();
       

        if (A == 2)
        {


            //太陽光見えなくする
            GameObject obj = GameObject.Find("Directional Light");
            obj.SetActive(false);

            //太陽光削除
            GameObject obj3 = GameObject.Find("SunLight");
            Destroy(obj3);

          
            //環境光黒色
            RenderSettings.ambientLight = Color.black;

        }
        else
        {
                GameObject obj4 = GameObject.Find("Spot Light");
                obj4.SetActive(false);
            }
        }
    }

