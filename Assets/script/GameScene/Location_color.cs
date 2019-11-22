using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location_color : MonoBehaviour
{
        // Start is called before the first frame update
        TextMesh text;
        bool flag=true;
        void Start()
        {
                text= this.GetComponent<TextMesh>();
        }

        // Update is called once per frame
        void Update()
        {
                if(Player.updown<-15&&flag==true) {
                        text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                        flag=false;
                }else if(Player.updown>-15&&flag==false) {
                        text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        flag=true;
                }
        }
}
