using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticule : MonoBehaviour
{
        private Vector3 replayer_position;
        private Vector3 replayer_forward;
        private Vector3 replayer_rotate;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
                replayer_position=Player.m_instance.transform.position;//自機のポジション
                replayer_forward=Player.m_instance.transform.forward;//自機ののベクトル
                replayer_rotate=Player.m_instance.transform.localEulerAngles;//自機の傾き
                var retipos =replayer_position+replayer_forward*4;
                //Debug.Log();
                //transform.localPosition =new Vector3(0f, 0f, 0f);
                transform.position =retipos;
                transform.localEulerAngles=replayer_rotate;
        }
}
