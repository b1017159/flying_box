using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticule : MonoBehaviour
{
        private Vector3 replayer_position;
        private Vector3 replayer_forward;
        private Vector3 replayer_rotate;
        // Start is called before the first frame update
        public int distance=4;
        private float color=0.0f;//初期透明度（透明）
        void Start()
        {
                if(this.name=="reticule") {
                        //Debug.Log(this.name);
                        gameObject.GetComponent<Renderer>().material.color=new Color(1,1,1,color);
                }
                //Color color=gameObject.GetComponent<Renderer>().material.color;
                //color.a=0.0f;
                //gameObject.GetComponent<Renderer>().material.color=color;
        }

        // Update is called once per frame
        void Update()
        {
                replayer_position=Player.m_instance.transform.position;//自機のポジション
                replayer_forward=Player.m_instance.transform.forward;//自機ののベクトル
                replayer_rotate=Player.m_instance.transform.localEulerAngles;//自機の傾き
                var retipos =replayer_position+replayer_forward*distance;
                //Debug.Log();
                //transform.localPosition =new Vector3(0f, 0f, 0f);
                transform.position =retipos;
                transform.localEulerAngles=replayer_rotate;
        }
}
