using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            LineRenderer Line = gameObject.GetComponent<LineRenderer>();
            // 線の幅
            Line.SetWidth(0.1f, 0.1f);
            // 頂点の数
            Line.SetVertexCount(2);
            // 頂点を設定
            Line.SetPosition(0, new Vector3(5.3f,-3f,0f));
            Line.SetPosition(1, new Vector3(6.8f, -3.5f, 0f));
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
