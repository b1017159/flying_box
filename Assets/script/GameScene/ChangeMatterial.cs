using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeMatterial : MonoBehaviour
{
    public Material[] _material;           // 割り当てるマテリアル.
    int i=0;


    // Update is called once per frame
    void Update()
    {
       i = OptionController.GetOneDay();

        if (i == 0)
        {
            this.GetComponent<Renderer>().sharedMaterial = _material[0];
        }
        else
        {
            this.GetComponent<Renderer>().sharedMaterial = _material[1];
        }
    }
}