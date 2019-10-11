﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
public class Player : MonoBehaviour {
        private Rigidbody rb; // Rididbody
        public float speed=0.01f; // 動く速さ
        public GameObject scoreText; // スコアの UI
        public float rotate_speed=0.5f;
        // public Camera maincamera;
        // プレイヤーのインスタンスを管理する static 変数
        public static Player m_instance;
        public float uemax=-60;//上に向く角度の最大値：負の値
        public float sitamax=60;//下に向く角度の最大値
        float updown = 0; //上下
        float sau = 0; //左右
        private int score;
        public static int scoredata = 0; // スコア
        private float size = 1.2f; // 巨大化
        // Start is called before the first frame update
        void Start() {
                // static 変数にインスタンス情報を格納する
                m_instance = this;
                score = 0;
                score = scoredata;
                SetCountText();
        }

        // Update is called once per frame
        void Update() {
                // use OVRInput
                OVRInput.Update();
                //Quaternion rotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
                //  Vector3 rotation = maincamera.transform.forward;
                // updown -= rotation.y * rotate_speed;
                //sau += rotation.x * rotate_speed;
                //   Debug.Log(rotation);
                //m_instance = this;
                //Debug.Log(this.transform.position);
                //Vector3 _Rotation = gameObject.transform.localEulerAngles;
                //Debug.Log("_Rotationl:"+_Rotation);
                // float angle_x = transform.eulerAngles.x;
                // float angle_y = transform.eulerAngles.y;
                // float angle_z = transform.eulerAngles.z;
                //Debug.Log(angle_x+":"+angle_y+":"+angle_z);
                //オブジェクトの角度を取得

                // カーソルキーの入力を取得
                // var moveHorizontal = Input.GetAxis("Horizontal");//横キー
                // var moveVertical = Input.GetAxis("Vertical");//縦キー
                // //Debug.Log(this.transform.localRotation.x);
                // if(angle_x<max&&angle_x>mini) {
                //         if(angle_x>max-20.0f) {
                //                 transform.rotation = Quaternion.Euler(max, angle_y, angle_z);
                //                 //オブジェクトを指定した角度にする
                //         }
                //         if(angle_x<100) {
                //                 transform.rotation = Quaternion.Euler(mini, angle_y, angle_z);
                //         }
                // }
                // //Debug.Log("moveHorizontal:"+moveHorizontal);
                // //Debug.Log("moveVertical:"+moveVertical);
                // // カーソルキーの入力に合わせて移動方向を設定
                // var movement = new Vector3(-moveVertical,moveHorizontal,0);
                // transform.Rotate(movement);
                //transform.Rotate(-moveVertical,moveHorizontal,0,Space.World);

                //oculasの左スティックで操作
                // updown -= OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).y * rotate_speed;
                // updown = Mathf.Clamp(updown, uemax, sitamax);
                // sau += OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x * rotate_speed;
                // 上方向ボタンを押した瞬間にif文の中を実行
                if (Input.GetKey(KeyCode.UpArrow) && updown > uemax)
                {
                        updown -= rotate_speed;
                }
                // 下方向ボタンを押した瞬間にif文の中を実行
                if (Input.GetKey(KeyCode.DownArrow) && updown < sitamax)
                {
                        updown += rotate_speed;
                }
                // 右方向ボタンを押した瞬間にif文の中を実行
                if (Input.GetKey(KeyCode.RightArrow))
                {
                        sau += rotate_speed;
                }
                // 左方向ボタンを押した瞬間にif文の中を実行
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                        sau -= rotate_speed;
                }

                // if (OVRInput.Get(OVRInput.RawButton.A)) {
                //         transform.Translate (0.0f, 0.0f, 0.1f);
                // }
                //
                // if (Input.GetKey(KeyCode.S))
                // {
                //         transform.Translate(0.0f, 0.0f, 0.1f);
                // }


                Debug.Log(OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).magnitude);
                //Debug.Log(updown+":"+sau);
                transform.rotation = Quaternion.Euler(updown, sau, 0 );
                transform.Translate (Vector3.forward * speed);
        }
        void OnTriggerEnter(Collider other) {
                if(other.gameObject.CompareTag("Enemy")) {
                        // その収集アイテムを非表示にします
                        other.gameObject.SetActive(false);
                        // スコアを加算します
                        score = score + 1;
                        size = size + score * 0.01f;
                        this.transform.localScale = new Vector3(size, size, size);
                        // UI の表示を更新します
                        SetCountText ();
                        //スコアを次のシーンに引き継ぐ
                        scoredata = score;
                }
        }
        // UI の表示を更新する
        void SetCountText() {
                // スコアの表示を更新
                //  scoreText.text = "Count: " + score.ToString();
                scoreText.GetComponent<TextMesh>().text = "Count: " + score.ToString();
        }
        public static int GetScore()
        {
                return scoredata;
        }

}
