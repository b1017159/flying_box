using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Toggle_Day : MonoBehaviour
{
    public static int oneDay;

    public void SetOneDay(int a)
    {
      oneDay = a;
      Debug.Log(a);
    }

    public void ChageMornning()
    {
        SetOneDay(0);
        transform.eulerAngles = new Vector3(90, 0, 0);

    }

    public void ChageNight()
    {
        SetOneDay(2);
        transform.eulerAngles = new Vector3(-90, 0, 0);
    }

    public static int GetOneDay()
    {
        return oneDay;
    }

}
