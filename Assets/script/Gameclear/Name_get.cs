using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name_get : MonoBehaviour
{
        // Start is called before the first frame update
        private Text targetText;  // <---- 追加2
        void Start()
        {
                //this.GetComponent<TextMesh>().text =InputFieldManager.name;
                //this.GetComponent<TextMesh>().text ="tesuto";
                this.targetText = this.GetComponent<Text>();
                this.targetText.text = InputName.GetName(); // テキストを名前に変更
                //print(InputName.GetName()+"giru");
        }

        // Update is called once per frame
        void Update()
        {

        }
}
