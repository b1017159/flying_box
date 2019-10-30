﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private GameObject FPS;　//一人称カメラ
    private GameObject TPS; //三人称カメラ
                            //　トータル制限時間
    private float totalTime;
    //　制限時間（分）
    [SerializeField]
    private int minute;
    //　制限時間（秒）
    [SerializeField]
    private float seconds;
    //　前回Update時の秒数
    private float oldSeconds;
    public static int minutedata;
    public static float secondsdata;
    public static float totaltimedata;
    private Rigidbody rb; // Rididbody
    public float speed = 0.01f; // 動く速さ
    //  public GameObject scoreText; // スコアの UI
    public float rotate_speed = 0.5f;
    // public Camera maincamera;
    // プレイヤーのインスタンスを管理する static 変数
    public static Player m_instance;
    public float uemax = -60;//上に向く角度の最大値：負の値
    public float sitamax = 60;//下に向く角度の最大値
    float updown = 0; //上下
    float sau = 0; //左右
    public static int ControllSwitch;
    public double score;
    public static float scaledata; //魚のスケールを引き継ぐための変数
    public static double scoredata = 1; // スコア
    public static int camerasig;
    private float size = 1.2f; // 巨大化
                               // Start is called before the first frame update
    public static int count = 0;
    public float scale;

    void Start()
    {
        // static 変数にインスタンス情報を格納する
        m_instance = this;
        score = 1;
        Time.timeScale = 1.0f;
        ControllSwitch = 1;
        // スコアを加算します
        score = scoredata;
        scale = scaledata;
        //   SetCountText();
        FPS = GameObject.Find("One_person");
        TPS = GameObject.Find("Third_person");
        camerasig = 3;
        TPS.SetActive(false);
        FPS.SetActive(true);
        totalTime = minute * 60 + seconds;
        minutedata = minute;
        secondsdata = seconds;
        totaltimedata = totalTime;

    }


    // Update is called once per frame
    void Update()
    {
        
        scale = this.transform.localScale.x;

        // use OVRInput
        OVRInput.Update();
        //　制限時間が0秒以下なら何もしない
        if (totalTime <= 0f)
        {
            return;
        }
        //Debug.Log(totalTime);
        //　一旦トータルの制限時間を計測；
        totalTime = minute * 60 + seconds;
        totalTime -= Time.deltaTime;
        totaltimedata = totalTime;
        //　再設定
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        minutedata = minute;
        secondsdata = seconds;

      if(ControllSwitch == 1)
        {
            //カメラの一人称と三人称の切り替え
          //  if (Input.GetKeyDown("space"))
            //{
                if (camerasig == 3)
                {
                    FPS.SetActive(false);
                    TPS.SetActive(true);
                }
                else
                {
                    FPS.SetActive(true);
                    TPS.SetActive(false);
                }
           // }
            //oculasの左スティックで操作
            updown -= OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).y * rotate_speed;
            updown = Mathf.Clamp(updown, uemax, sitamax);
            sau += OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x * rotate_speed;
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

            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                transform.Translate(0.0f, 0.0f, 0.1f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0.0f, 0.0f, 0.1f);
            }
        }
        //Debug.Log(OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).magnitude);
        //Debug.Log(updown+":"+sau);
        transform.rotation = Quaternion.Euler(updown, sau, 0);
        transform.Translate(Vector3.forward * speed * Time.timeScale);

    }

        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (this.scale + score > other.gameObject.GetComponent<Enemy>().scale)
            {
                Debug.Log(this.scale + score + ":::::::" + other.gameObject.GetComponent<Enemy>().scale + "大きくなるよ!!");

                // その収集アイテムを非表示にします
                other.gameObject.SetActive(false);
                // スコアを加算します
                //
                if(other.gameObject.GetComponent<Enemy>().scale < this.scale + score - 1)
                {
                    score = score + 0.01;  // スコアを加算します
                    size = size + 1 * 0.001f;
                    Debug.Log(size);

                }else
                {
                    score = score + 0.1;　//スコアを加算
                    size = size + 1 * 0.01f;
                    Debug.Log(size);
                } 
                this.transform.localScale = new Vector3(size, size, size);
                //スコアを次のシーンに引き継ぐ
                scoredata = score;
                scaledata = scale;
            }
            if (this.scale + score <= other.gameObject.GetComponent<Enemy>().scale)
            {
                Debug.Log(this.scale + score + ":::::::" + other.gameObject.GetComponent<Enemy>().scale + "HP一つ消えるで!!");
                //自分より大きい魚にぶつかったらカウントを+1
                count++;
                    other.gameObject.SetActive(false);
            }

        }
    }
}
