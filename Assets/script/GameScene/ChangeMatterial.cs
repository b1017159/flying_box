using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeMatterial : MonoBehaviour
{
    public Material[] _material;           // 割り当てるマテリアル.
    int i = 0;
   

    void Start()
    {
        //朝夜の判断
        i = Toggle_Day.GetOneDay();
    }

    // Update is called once per frame
    void Update()
    {
        //夜背景に変更
        if (i==2){
            this.GetComponent<Renderer>().sharedMaterial = _material[1];
   
            // 環境光のライティング設定
            // ソースをFlatに変更する
            //RenderSettings.ambientMode = AmbientMode.Flat;
            // 環境光の色を指定する
            RenderSettings.ambientLight = Color.black;
            }
    }
}