﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //効果音
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    private AudioSource audioSource;

    bool damage_swich;//真か偽か？
    //public float riku = 2;//2秒間表示
    Color color;
    public GameObject damage;

    private Vector3 FPS_forward;
    private Vector3 FPS_rotate;

    public Transform FPS_camera_forward;

    public static int Camerasignal;

    public GameObject fish;
    public GameObject fish2;

    private GameObject reticuleFPS;
    private GameObject reticuleTPS;
    private GameObject reticule_picFPS;
    private GameObject reticule_picTPS;
    private GameObject damagecube;

    private GameObject FPS;
    　//一人称カメラ
    private GameObject TPS; //三人称カメラ
    private float totalTime;//　トータル制限時間
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
    public int score;
    public static int scoredata = 0; // スコア
    private float size = 1.2f; // 巨大化
    // Start is called before the first frame update
    public static int count = 0;
    public float scale;


    private void Awake()
    {
        // static 変数にインスタンス情報を格納する
        m_instance = this;
    }

    void Start()
    {
        damage_swich = false;
        damagecube = GameObject.Find("TPS_Damage_Effect");
        damagecube = GameObject.Find("FPS_Damage_Effect");
        damagecube.SetActive(false);
        //初期化
        reticuleFPS = GameObject.Find("reticuleFPS");
        reticuleTPS = GameObject.Find("reticuleTPS");
        reticule_picFPS = GameObject.Find("reticule_picFPS");
        reticule_picTPS = GameObject.Find("reticule_picTPS");
        score = 0;
        score = scoredata;
        //   SetCountText();
        FPS = GameObject.Find("First_person");
        TPS = GameObject.Find("Third_person");
        TPS.SetActive(false);
        totalTime = minute * 60 + seconds;
        minutedata = minute;
        secondsdata = seconds;
        totaltimedata = totalTime;
        Camerasignal = CountTimer.signal;
        if (Camerasignal == 1) {
            FPS.SetActive(true);
            TPS.SetActive(false);
            fish.SetActive(false);
            fish2.SetActive(false);//自身の魚を見えなくする
            reticuleFPS.SetActive(true);
            reticuleTPS.SetActive(false);
        } else {
            FPS.SetActive(false);
            TPS.SetActive(true);

            reticuleFPS.SetActive(false);
            reticuleTPS.SetActive(true);
        }

        FPS_camera_forward = transform.Find("First_person");

    }

    // Update is called once per frame
    void Update()
    {
       
        
       // damagecube.SetActive(false);
       if(damage_swich == true)
        {
            
            print("Noooooob");
             //DelayMethodを0.2秒後に呼び出す
            Invoke("damageEFON", 0.2f);//ダメージ食らう
            
            Invoke("damageEFOFF", 0.5f);//ダメージ消える
            damage_swich = false;
        }
       
        
        

        FPS_forward = FPS_camera_forward.forward;
        FPS_rotate = FPS_camera_forward.localEulerAngles;

        //Debug.Log("FPS_rotate" + FPS_rotate);

        scale = this.transform.localScale.x + 9;

        // use OVRInput
        OVRInput.Update();
        //　制限時間が0秒以下なら何もしない
        if (totalTime <= 0f) {
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

        //カメラの一人称と三人称の切り替え
        if (Input.GetKeyDown("space")) {
            if (FPS.activeSelf) {
                FPS.SetActive(false);
                TPS.SetActive(true);
                //    scoreText = GameObject.Find("3DScore");
                fish.SetActive(true);
                fish2.SetActive(true);//自身の魚がみえてる
                reticuleFPS.SetActive(false);
                reticuleTPS.SetActive(true);
                reticule_picFPS.SetActive(false);
                reticule_picTPS.SetActive(true);
            } else {
                FPS.SetActive(true);
                TPS.SetActive(false);
                fish.SetActive(false);
                fish2.SetActive(false);//自身の魚を見えなくする
                reticuleFPS.SetActive(true);
                reticuleTPS.SetActive(false);
                reticule_picFPS.SetActive(true);
                reticule_picTPS.SetActive(false);
            }
        }

        if (TPS.activeSelf) {
            //oculasの左スティックで操作
            updown -= OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).y * rotate_speed;
            updown = Mathf.Clamp(updown, uemax, sitamax);
            sau += OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x * rotate_speed;
            // 上方向ボタンを押した瞬間にif文の中を実行
            if (Input.GetKey(KeyCode.UpArrow) && updown > uemax) {
                updown -= rotate_speed;
            }
            // 下方向ボタンを押した瞬間にif文の中を実行
            if (Input.GetKey(KeyCode.DownArrow) && updown < sitamax) {
                updown += rotate_speed;
            }
            // 右方向ボタンを押した瞬間にif文の中を実行
            if (Input.GetKey(KeyCode.RightArrow)) {
                sau += rotate_speed;
            }
            // 左方向ボタンを押した瞬間にif文の中を実行
            if (Input.GetKey(KeyCode.LeftArrow)) {
                sau -= rotate_speed;
            }

            if (OVRInput.Get(OVRInput.RawButton.A)) {
                transform.Translate(0.0f, 0.0f, 0.1f);
            }

            if (Input.GetKey(KeyCode.S)) {
                transform.Translate(0.0f, 0.0f, 0.1f);
            }

            //Debug.Log(OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).magnitude);
            //Debug.Log(updown+":"+sau);
            transform.rotation = Quaternion.Euler(updown, sau, 0);
            transform.Translate(Vector3.forward * speed);
        }

        else {
            //FPSの時、向いた方向に進みます
            //transform.rotation = Quaternion.Euler(FPS_rotate);
            //transform.Translate(Vector3.forward * speed);
            transform.Translate(FPS_camera_forward.forward * speed);
        }

    }

        

         void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) {
            if (this.scale / 10 > other.gameObject.GetComponent<Enemy>().scale) {
                Debug.Log(this.scale / 10 + ":::::::" + other.gameObject.GetComponent<Enemy>().scale + "大きくなるよ!!");

                // その収集アイテムを非表示にします
                other.gameObject.SetActive(false);
                // スコアを加算します
                score = score + 1;
                size = size + score * 0.01f;
                this.transform.localScale = new Vector3(size, size, size);
                //スコアを次のシーンに引き継ぐ
                scoredata = score;
                audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.clip = audioClip1;
                audioSource.Play ();
            }

            if (this.scale / 10 <= other.gameObject.GetComponent<Enemy>().scale) {
                Debug.Log(this.scale / 10 + ":::::::" + other.gameObject.GetComponent<Enemy>().scale + "HP一つ消えるで!!");
                //自分より大きい魚にぶつかったらカウントを+1
                count++;
                //damagecube.SetActive(true);
                damage_swich= true;
                other.gameObject.SetActive(false);
                audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.clip = audioClip2;
                audioSource.Play ();
            }

        }
    }
 void damageEFON()
        {
            damagecube.SetActive(true);
            print("ダメージONがよばれています");
        }
        void damageEFOFF()
        {
            damagecube.SetActive(false);
            print("ダメージOFFがよばれています");
        }

}
