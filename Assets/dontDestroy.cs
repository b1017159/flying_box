using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    public GameObject Fish;

    public void DontDestroyOnLoad()
    {
        DontDestroyOnLoad(Fish);
    }


}