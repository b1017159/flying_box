using System.Collections;
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

        //一人称時のカメラの向きを取得するときに使用するぜ
        private Vector3 FPS_forward;
        private Vector3 FPS_rotate;
        public Transform FPS_camera_forward;
    public Transform TPS_camera_forward;

    //カメラが一人称か、三人称か判定するときに使用するぜ
    public static int Camerasignal;

        //自分の魚を消すときのオブジェクト宣言
        public GameObject Armature;
        public GameObject Plane_001;

        //レティクル関係のオブジェクト宣言
        private GameObject reticuleFPS;
        private GameObject reticuleTPS;
        private GameObject reticule_picFPS;
        private GameObject reticule_picTPS;

        //ダメージエフェクトのオブジェクト宣言
        public GameObject damagecube_TPS;//TPSでのダメージエフェクト宣言
        public GameObject damagecube_FPS;//FPSでのダメージエフェクト宣言

        //カメラのオブジェクト宣言
        private GameObject FPS; //一人称カメラ
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
        public static float sizedata = 0.9f; //魚のスケールを引き継ぐための変数
        public static double scoredata = 30; // スコア
        public static int camerasig = 3;
        private float size = 3f;//初期大きさ
        private float scale_multiple=0.3f;
        public static int count = 0;
    public float scale;
      //  public static float sizedata;

        //コントローラの宣言
        OVRInput.Controller LeftCon;
        OVRInput.Controller RightCon;

        //速度制限で使うぜ
        public float Max_speed = 1.00f;
        public float Min_speed = 0.01f;
        public float Speed_Down;
        public MP3 mp3;//.Mswichの数字でSE管理
        private void Awake()
        {
                // static 変数にインスタンス情報を格納する
                m_instance = this;
        }

        void Start()
        {

                //コントローラーの初期化
                LeftCon = OVRInput.Controller.LTouch;
                RightCon = OVRInput.Controller.RTouch;


                //レティクル関係の初期化
                reticuleFPS = GameObject.Find("reticuleFPS"); 　　　　　//シーン内でのレティクル棒を検索（FPS）
                        reticuleTPS = GameObject.Find("reticuleTPS"); //シーン内でのレティクル棒を検索（TPS）
                reticule_picFPS = GameObject.Find("reticule_picFPS"); //シーン内でのレティクル画像を検索（FPS）
                reticule_picTPS = GameObject.Find("reticule_picTPS"); //シーン内でのレティクル画像を検索（TPS）


                // static 変数にインスタンス情報を格納する
                m_instance = this;
                Time.timeScale = 1.0f;
                ControllSwitch = 1;
                // スコアを加算します
                score = scoredata;
        scale = sizedata; //scale = size
        //size = sizedata;
                

        //   SetCountText();
        FPS = GameObject.Find("First_person");//シーン内での一人称カメラを探す
                TPS = GameObject.Find("Third_person");//シーン内での三人称カメラを探す
                camerasig = 3;
                TPS.SetActive(false);
                //FPS.SetActive(true);
                totalTime = minute * 60 + seconds;
                minutedata = minute;
                secondsdata = seconds;

                totaltimedata = totalTime;

                damagecube_TPS.SetActive(false);//初期の段階はエフェクトoff
                damagecube_FPS.SetActive(false);//初期の段階はエフェクトoff

      
                Camerasignal = CountTimer.signal;
                camerasig = Camerasignal;

                //カメラシグナルが１の時、一人称カメラが起動して、自身の姿が見えなくなる。また、レティクルも一人称専用のレティクルが起動する。
                if (camerasig == 1)
                {
                        FPS.SetActive(true);
                        TPS.SetActive(false);
                        Armature.SetActive(false);
                        Plane_001.SetActive(false);//自身の魚を見えなくする
                        reticuleFPS.SetActive(true);
                        reticuleTPS.SetActive(false);

                }
                else
                {
                        //カメラシグナルが３の時、カメラシグナル１の逆
                        FPS.SetActive(false);
                        TPS.SetActive(true);
                        Armature.SetActive(true);
                        Plane_001.SetActive(true);//自身の魚を見えなくする
                        reticuleFPS.SetActive(false);
                        reticuleTPS.SetActive(true);
          

        }

                FPS_camera_forward = transform.Find("First_person");//FPS時に向いている方向を取得？
        TPS_camera_forward = transform.Find("Third_person");//FPS時に向いている方向を取得？
        this.transform.localScale=new Vector3(scale,scale,scale);
        }


        // Update is called once per frame
        void Update()
        {
                FPS_forward = FPS_camera_forward.forward;//一人称視点の時に自機のベクトルを取得
                FPS_rotate = FPS_camera_forward.localEulerAngles;//一人称視点の時に自機の傾きを取得

                scale = this.transform.localScale.x;//自分の大きさを取得（サイズ）
        //Debug.Log(scale);



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

                if (ControllSwitch == 1)
        {
           // Debug.Log(TPS_camera_forward.transform.rotation);

            if (camerasig == 3)
                        {
                                //三人称にしたときに、自身が見えるようにするのと、一人称のレティクル関係を消す
                                //自身の魚がみえてる
                                FPS.SetActive(false);
                                TPS.SetActive(true);
                                Armature.SetActive(true);
                                Plane_001.SetActive(true);//自身の魚がみえてる
                                reticuleFPS.SetActive(false);
                                reticuleTPS.SetActive(true);
                                reticule_picFPS.SetActive(false);
               
               
                                reticule_picTPS.SetActive(true);
            }
                        else
                        {
                                //一人称にしたときに、三人称と逆のこと
                                transform.rotation = Quaternion.Euler(FPS_forward);//自身の向きをカメラの向きにそろえる
                                //自身の魚を見えなくする
                                FPS.SetActive(true);
                                TPS.SetActive(false);
                                Armature.SetActive(false);
                                Plane_001.SetActive(false);
                                reticuleFPS.SetActive(true);
                                reticuleTPS.SetActive(false);
                                reticule_picFPS.SetActive(true);
                                reticule_picTPS.SetActive(false);

                        }


                        //三人称時はオキュラスのコントローラで操作
                        if (TPS.activeSelf)
                        {
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

                                if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
                                {
                                        transform.Translate(0.0f, 0.0f, 0.1f);
                                }

                                if (Input.GetKey(KeyCode.S))
                                {
                                        transform.Translate(0.0f, 0.0f, 0.1f);
                                }


                                transform.rotation = Quaternion.Euler(updown, sau, 0); 
                                transform.Translate(Vector3.forward * speed);
                        }
                        else
                        {
                                //FPSの時、向いた方向に進みます
                                transform.Translate(FPS_camera_forward.transform.forward * speed);
                                //加速度を取得
                                Vector3 accLeft = OVRInput.GetLocalControllerAcceleration(LeftCon);
                                Vector3 accRight = OVRInput.GetLocalControllerAcceleration(RightCon);

                                //三次元ベクトルからfloatに変換
                                float Rlength = accRight.magnitude;
                                float Llength = accLeft.magnitude;

                                //閾値を指定（振ってないとき加速度を0にします）
                                if (Rlength <= 2.0f)
                                {
                                        Rlength = 0.0f;
                                }
                                if (Llength <= 2.0f)
                                {
                                        Llength = 0.0f;
                                }

                                //左右のコントローラの加速度を足します
                                float Sam_Length = (Rlength + Llength) / 50.0f;

                                //水槽のなか
                                Speed_Down += Sam_Length;

                                //0,005ずつ速度が下がります
                                Speed_Down -= 0.005f;

                                //加速制限を設けた
                                Speed_Down = Mathf.Clamp(Speed_Down, Min_speed, Max_speed);

                                //制限したものを返す
                                speed = Speed_Down;

                        }
                }
        }

        //ダメージ判定関数
        void damageEFON()
        {
                damagecube_FPS.SetActive(true);//ダメージエフェクトを表示する
                damagecube_TPS.SetActive(true);
        }
        void damageEFOFF()
        {
                damagecube_FPS.SetActive(false);//ダメージエフェクトを非表示にするよ
                damagecube_TPS.SetActive(false);
        }

        //当たり判定
        void OnTriggerEnter(Collider other)
        {
                if (other.gameObject.CompareTag("Enemy"))
                {
                        if (this.scale > other.gameObject.GetComponent<Enemy>().scale)
                        {
                                Debug.Log(this.scale + score + ":::::::" + other.gameObject.GetComponent<Enemy>().scale + "大きくなるよ!!");

                                // その収集アイテムを非表示にします
                                other.gameObject.SetActive(false);
                                // スコアを加算します
                                score = score + 1; // スコアを加算します
                                scale = scale + 0.03f;
                                this.transform.localScale = new Vector3(scale, scale,scale);
                                //スコアを次のシーンに引き継ぐ
                                scoredata = score;
                                sizedata = scale;//scale=size
                
                                mp3.Mswich=1;//咀嚼音
                        }
                        if (this.scale <= other.gameObject.GetComponent<Enemy>().scale)
                        {
                                Debug.Log(this.scale + score + ":::::::" + other.gameObject.GetComponent<Enemy>().scale + "HP一つ消えるで!!");
                                //自分より大きい魚にぶつかったらカウントを+1
                                count++;
                                other.gameObject.SetActive(false);

                                Invoke("damageEFON", 0.2f);//ダメージ食らう
                                Invoke("damageEFOFF", 0.5f);//ダメージ消える
                                mp3.Mswich=2;//ダメージ音
                        }
                }
        }



}
