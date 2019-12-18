using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class OptionController : MonoBehaviour
{
        public GameObject status; //スコアやタイムなどを全て格納
        private int Camerasig;
        private int Lighting;
        public AudioClip OpenOption;
        AudioSource audioSource;
        public GameObject OptionMenu; //オプションに関するObjectを全て格納
        public GameObject checkbox_camera;
        public GameObject checkbox_sound;
        public GameObject checkbox_gotitle;
        public GameObject checkbox_backgame;
        public GameObject checkbox_yes;
        public GameObject checkbox_no;
        public GameObject CameraText_3; //選択時のTPSの文字表示
        public GameObject CameraText_1; //選択時のFPSの文字表示
        public GameObject CameraText_3_non; //非選択時のTPSの文字表示
        public GameObject CameraText_1_non; //非選択時のTPSの文字表示
        public GameObject LightText_3; //選択時の朝の文字表示
        public GameObject LightText_1; //選択時の夜の文字表示
        public GameObject LightText_3_non; //非選択時の朝の文字表示
        public GameObject LightText_1_non; //非選択時の夜の文字表示
        public GameObject sound;
        public GameObject YesTitle;
        public GameObject menuText;
        public GameObject spotlight;
        public GameObject sunlight;
        private GameObject FPS; //一人称カメラ
        private int changemenu; //メニューを切り替えるための変数
        private int mode; //オプションとゲームシーンを切り替え
        public static int oneDay;
        int zyouge=0;//メニュー画面で上下移動するためのフラグ
        // Start is called before the first frame update

        void Start()
        {
                audioSource = GetComponent<AudioSource>();
                //シーン移行しても継続
                Lighting = GetOneDay();

                mode = 0;
                changemenu = 0;
                FPS = GameObject.Find("One_person");

                if (FPS.activeSelf)
                {
                        CameraText_1.SetActive(false);
                        CameraText_1_non.SetActive(true);
                        CameraText_3.SetActive(true);
                        CameraText_3_non.SetActive(false);
                }
                else
                {
                        CameraText_1.SetActive(true);
                        CameraText_1_non.SetActive(false);
                        CameraText_3.SetActive(false);
                        CameraText_3_non.SetActive(true);
                }

                if (Lighting == 0)
                {
                        LightText_1.SetActive(true);
                        LightText_3.SetActive(false);
                        SetOneDay(0);
                        spotlight.SetActive(false);
                        sunlight.SetActive(true);
                }
                else
                {
                        LightText_1.SetActive(false);
                        LightText_3.SetActive(true);
                        SetOneDay(1);
                        spotlight.SetActive(true);
                        sunlight.SetActive(false);
                }
        }

        // Update is called once per frame
        void Update()
        {
                if (changemenu != 5 && changemenu != 9 && (Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown ("joystick button 3")))
                {
                        audioSource.PlayOneShot(OpenOption);
                        mode = 1;
                        changemenu = 0;
                        Player.ControllSwitch = 0;
                        Time.timeScale = 0;
                }
                if (mode == 1)
                {
                        float hori = Input.GetAxis ("Horizontal");
                        float vert = Input.GetAxis ("Vertical");
                        if(vert != 0) {
                                if(vert>0&&zyouge<0) zyouge=0;
                                if(vert<0&&zyouge>0) zyouge=0;
                        }else{//カーソルが高速移動するため制限をかける
                                zyouge=0;
                        }
                        status.SetActive(false);
                        OptionMenu.SetActive(true);
                        sound.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.Backspace)||Input.GetKeyDown ("joystick button 0"))
                        {
                                audioSource.PlayOneShot(OpenOption);
                                if (Camerasig == 1)
                                {
                                        Player.camerasig = 1;
                                }
                                else
                                {
                                        Player.camerasig = 3;
                                }
                                mode = 0;
                                Player.ControllSwitch = 1;
                                Time.timeScale = 1.0f;
                        }
                        if (changemenu != 5 && changemenu != 9 && (Input.GetKeyDown(KeyCode.DownArrow)||(vert<-0.75&&zyouge==0)))
                        {
                                changemenu += 1;//上下移動
                                zyouge--;
                        }
                        if (changemenu != 5 && changemenu != 9 && (Input.GetKeyDown(KeyCode.UpArrow)||(vert>0.75&&zyouge==0)))
                        {
                                changemenu -= 1;
                                zyouge++;
                        }
                        if (changemenu == 5 && (Input.GetKeyDown(KeyCode.RightArrow)||hori>0.75))
                        {
                                changemenu += 4;
                        }
                        if (changemenu == 9 && (Input.GetKeyDown(KeyCode.LeftArrow)||hori<-0.75))
                        {
                                changemenu -= 4;
                        }
                        if (changemenu == 0)
                        {
                                checkbox_camera.SetActive(true);
                                checkbox_sound.SetActive(false);
                                checkbox_gotitle.SetActive(false);
                                checkbox_backgame.SetActive(false);
                                checkbox_yes.SetActive(false);
                                checkbox_no.SetActive(false);
                                YesTitle.SetActive(false);
                                if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown ("joystick button 1")) //カメラの切り替えを行う
                                {
                                        Debug.Log(Camerasig);
                                        if (Camerasig == 1)
                                        {
                                                CameraText_1.SetActive(false);
                                                CameraText_1_non.SetActive(true);
                                                CameraText_3.SetActive(true);
                                                CameraText_3_non.SetActive(false);

                                                Camerasig = 3;
                                        }
                                        else
                                        {
                                                CameraText_1.SetActive(true);
                                                CameraText_1_non.SetActive(false);
                                                CameraText_3.SetActive(false);
                                                CameraText_3_non.SetActive(true);
                                                Camerasig = 1;
                                        }
                                }
                        }
                }
                else
                {
                        status.SetActive(true);
                        OptionMenu.SetActive(false);
                        sound.SetActive(true);

                }
                //メニューごとに実行内容を変更
                if (changemenu == -1)
                {
                        changemenu = 3;
                }
                if (changemenu == 1)
                {
                        checkbox_camera.SetActive(false);
                        checkbox_sound.SetActive(true);
                        checkbox_gotitle.SetActive(false);
                        checkbox_backgame.SetActive(false);
                        checkbox_yes.SetActive(false);
                        checkbox_no.SetActive(false);
                        if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown ("joystick button 1")) //カメラの切り替えを行う
                        {//夜
                                if (Lighting == 0)
                                {
                                        LightText_1.SetActive(false);
                                        LightText_1_non.SetActive(true);
                                        LightText_3.SetActive(true);
                                        LightText_3_non.SetActive(false);

                                        spotlight.SetActive(true);
                                        sunlight.SetActive(false);

                                        SetOneDay(1);
                                        Lighting = 3;
                                }
                                else　//朝
                                {
                                        LightText_1.SetActive(true);
                                        LightText_1_non.SetActive(false);
                                        LightText_3.SetActive(false);
                                        LightText_3_non.SetActive(true);
                                        spotlight.SetActive(false);
                                        sunlight.SetActive(true);

                                        SetOneDay(0);
                                        Lighting = 0;
                                }
                        }
                }
                if (changemenu == 2)
                {
                        checkbox_camera.SetActive(false);
                        checkbox_sound.SetActive(false);
                        checkbox_gotitle.SetActive(true);
                        checkbox_backgame.SetActive(false);
                        checkbox_yes.SetActive(false);
                        checkbox_no.SetActive(false);
                        if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown ("joystick button 1"))
                        {
                                changemenu = 5;
                                YesTitle.SetActive(true);
                                menuText.SetActive(false);
                                return;
                        }
                }

                if (changemenu == 3)
                {
                        checkbox_camera.SetActive(false);
                        checkbox_sound.SetActive(false);
                        checkbox_gotitle.SetActive(false);
                        checkbox_backgame.SetActive(true);
                        checkbox_yes.SetActive(false);
                        checkbox_no.SetActive(false);

                        if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown ("joystick button 1"))
                        {
                                audioSource.PlayOneShot(OpenOption);
                                if (Camerasig == 1)
                                {
                                        Player.camerasig = 1;

                                }
                                else
                                {
                                        Player.camerasig = 3;

                                }
                                mode = 0;
                                Player.ControllSwitch = 1;
                                Time.timeScale = 1.0f;
                        }
                }
                if (changemenu == 4)
                {
                        changemenu = 0;
                }

                if (changemenu == 5)
                {//gametitleに戻る
                        checkbox_yes.SetActive(true);
                        checkbox_no.SetActive(false);
                        checkbox_camera.SetActive(false);
                        checkbox_sound.SetActive(false);
                        checkbox_gotitle.SetActive(false);
                        checkbox_backgame.SetActive(false);
                        Player.scoredata=30;
                        if (Input.GetKey(KeyCode.Y)||Input.GetKeyDown ("joystick button 1"))
                        {
                                SceneManager.LoadScene("GameTitle");
                        }
                }

                if (changemenu == 9)
                {
                        checkbox_yes.SetActive(false);
                        checkbox_no.SetActive(true);
                        checkbox_camera.SetActive(false);
                        checkbox_sound.SetActive(false);
                        checkbox_gotitle.SetActive(false);
                        checkbox_backgame.SetActive(false);
                        if (Input.GetKeyDown(KeyCode.N)||Input.GetKeyDown ("joystick button 1"))
                        {
                                changemenu = 2;
                                YesTitle.SetActive(false);
                                checkbox_camera.SetActive(false);
                                checkbox_sound.SetActive(false);
                                checkbox_gotitle.SetActive(true);
                                checkbox_backgame.SetActive(false);
                                checkbox_yes.SetActive(false);
                                checkbox_no.SetActive(false);
                                menuText.SetActive(true);
                        }
                }
        }

        private void SetOneDay(int a)
        {
                oneDay = a;
        }

        public static int GetOneDay()
        {
                return oneDay;
        }

}
