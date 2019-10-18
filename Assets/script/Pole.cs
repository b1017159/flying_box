using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
        private Vector3 poleplayer_position;
        private Vector3 poleplayer_forward;
        private Vector3 poleplayer_rotate;
        public float distance=10f;//最大スケール
        public static Pole m_instance;
        // Start is called before the first frame update
        void Start()
        {
                m_instance=this;
        }

        // Update is called once per frame
        void Update()
        {
                poleplayer_position=Player.m_instance.transform.position;//自機のポジション
                poleplayer_forward=Player.m_instance.transform.forward;//自機ののベクトル
                poleplayer_rotate=Player.m_instance.transform.localEulerAngles;//自機の傾き
                var polepos =poleplayer_position-poleplayer_forward*distance;
                transform.position =polepos;
                transform.localEulerAngles=poleplayer_rotate;
        }
}
