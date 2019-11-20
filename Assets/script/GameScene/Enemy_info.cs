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
        private float color = 0;//初期透明度（透明）
        private float one_hund_scale;
        void Start()
        {
                pare_enemy = transform.root.gameObject;
                if(pare_enemy==null) Debug.Log("enemy_infoの親オブジェクト無いぞ");
                //gameObject.GetComponent<Renderer>().material.color=new Color(1,1,1,color);//透明化
                myRectTfm = GetComponent<RectTransform>();
                gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, color);//透明化
        }

        // Update is called once per frame
        void Update()
        {
                //if(color<1) color=color+0.01f;
                gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, color);
                //最初は透明だが時間経過で色がつく
                //replayer_rotate=Player.m_instance.transform.localEulerAngles;//自機の傾き
                //replayer_rotate.z=-replayer_rotate.z;
                //transform.localEulerAngles=replayer_rotate;
                if (!(transform.parent == null)) pare_enemy = transform.parent.gameObject;
                //親がいるなら親のgameobjectを取得
                pare_pos = transform.parent.position;
                pare_pos.y = pare_pos.y - 0.03f;
                pare_pos.z = pare_pos.z - 0.08f;
                transform.position = pare_pos;
                // 自身の向きをカメラに向ける
                myRectTfm.LookAt(Camera.main.transform);
                this.transform.forward = new Vector3(this.transform.position.x - Camera.main.transform.position.x, this.transform.position.y - Camera.main.transform.position.y, this.transform.position.z - Camera.main.transform.position.z);

        }
        public void Display(float scale,float multiple, string name)
        {
                one_hund_scale=scale*(100/(multiple*10));
                string enemy_scale = one_hund_scale.ToString("F0") +"cm"+"\n "+ name;
                //string enemy_scale = scale.ToString("F2")+"\n "+ name;//メートル用
                //Fで小数点指定
                //Debug.Log(enemy_scale+":"+"scale");
                this.GetComponent<RectTransform>().localScale = new Vector3(1/scale/2, 1/scale/2, 1/scale/2);
                this.GetComponent<TextMesh>().text = enemy_scale;
        }
        public void Aaper()
        {
                //public voidを忘れないように
                color = 100;
        }
        public void Color_zero()
        {
                color = 0;
        }
}
