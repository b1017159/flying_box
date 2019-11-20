using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeMatterial : MonoBehaviour
{
    public Material[] _material;           // 割り当てるマテリアル.
    public static int material;

    void Start()
    {
        material = OptionController.GetOneDay();
    }

    // Update is called once per frame
    void Update()
    {
        material = OptionController.GetOneDay();

        if (material == 0)
        {
            this.GetComponent<Renderer>().sharedMaterial = _material[0];
            // 環境光の色を指定する
            RenderSettings.ambientLight = Color.white;
        }
        else
        {
            this.GetComponent<Renderer>().sharedMaterial = _material[1];
            // 環境光の色を指定する
            RenderSettings.ambientLight = Color.black;
        }
    }
}