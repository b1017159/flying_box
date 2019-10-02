using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_info : MonoBehaviour
{
        // Start is called before the first frame update
        //private Vector3 replayer_rotate;
        public GameObject pare_enemy;
        public Vector3 pare_pos;
        //小文字にしない
        private RectTransform myRectTfm;
        private float color=0;//初期透明度（透明）
        public GameObject messageText;
        void Start()
        {
                //gameObject.GetComponent<Renderer>().material.color=new Color(1,1,1,color);//透明化
                myRectTfm = GetComponent<RectTransform>();
        }

        // Update is called once per frame
        void Update()
        {
                //replayer_rotate=Player.m_instance.transform.localEulerAngles;//自機の傾き
                //replayer_rotate.z=-replayer_rotate.z;
                //transform.localEulerAngles=replayer_rotate;
                if(!(transform.parent==null)) pare_enemy=transform.parent.gameObject;
                //親がいるなら親のgameobjectを取得
                pare_pos=transform.parent.position;
                pare_pos.y=pare_pos.y-0.03f;
                pare_pos.z=pare_pos.z-0.08f;
                transform.position=pare_pos;
                // 自身の向きをカメラに向ける
                myRectTfm.LookAt(Camera.main.transform);
        }
        void Display(float scale){
                string enemy_scale=scale.ToString();
                messageText.GetComponent<TextMesh>().text = enemy_scale;
        }
}
