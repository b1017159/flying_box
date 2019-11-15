using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
public class OptionController : MonoBehaviour
{
    public GameObject status; //スコアやタイムなどを全て格納
    private int Camerasig;
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
    public GameObject sound;
    public GameObject YesTitle;
    public GameObject menuText;

    private int changemenu; //メニューを切り替えるための変数
    private int mode; //オプションとゲームシーンを切り替え
    // Start is called before the first frame update
    void Start()
    {
       
        mode = 0;
        changemenu = 0;
        Camerasig = Player.camerasig;
        if (Camerasig == 1)
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
    }

    // Update is called once per frame
    void Update()
    {
        
        if (changemenu != 5 && changemenu != 9 && OVRInput.GetDown(OVRInput.RawButton.X))

        {
            mode = 1;
            changemenu = 0;
            Player.ControllSwitch = 0;
            Time.timeScale = 0;
        }
        
        if (changemenu != 5 && changemenu !=9 && OVRInput.GetDown(OVRInput.RawButton.LThumbstickDown))
        {
            changemenu += 1;
        }
        if (changemenu != 5 && changemenu !=9 && OVRInput.GetDown(OVRInput.RawButton.LThumbstickUp))
        {
            changemenu -= 1;
        }
        if (changemenu == 5 && OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight))
        {
            changemenu += 4;
        }
        if (changemenu == 9 && OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft))
        {
            changemenu -= 4;
        }

        //メニューごとに実行内容を変更
        if (changemenu == -1)
        {
            changemenu = 3;
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
                if (OVRInput.GetDown(OVRInput.RawButton.A)) //カメラの切り替えを行う
            {
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
        if (changemenu == 1)
        {
            checkbox_camera.SetActive(false);
            checkbox_sound.SetActive(true);
            checkbox_gotitle.SetActive(false);
            checkbox_backgame.SetActive(false);
            checkbox_yes.SetActive(false);
            checkbox_no.SetActive(false);
        }
        if (changemenu == 2)
        {
            checkbox_camera.SetActive(false);
            checkbox_sound.SetActive(false);
            checkbox_gotitle.SetActive(true);
            checkbox_backgame.SetActive(false);
            checkbox_yes.SetActive(false);
            checkbox_no.SetActive(false);
                if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                changemenu = 5;
                YesTitle.SetActive(true);
                menuText.SetActive(false);
            }
            /* if (OVRInput.GetDown(OVRInput.RawButton.A))
             {
                 SceneManager.LoadScene("GameTitle");
             }*/
        }

        if (changemenu == 3)
        {
            checkbox_camera.SetActive(false);
            checkbox_sound.SetActive(false);
            checkbox_gotitle.SetActive(false);
            checkbox_backgame.SetActive(true);
            checkbox_yes.SetActive(false);
            checkbox_no.SetActive(false);

                if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                if(Camerasig == 1)
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
        if(changemenu == 4)
        {
            changemenu = 0;
        }

        //Debug.Log(changemenu);

        if (changemenu == 5)
        {
            checkbox_yes.SetActive(true);
            checkbox_no.SetActive(false);
            checkbox_camera.SetActive(false);
            checkbox_sound.SetActive(false);
            checkbox_gotitle.SetActive(false);
            checkbox_backgame.SetActive(false);
                if (OVRInput.GetDown(OVRInput.RawButton.A)) //カメラの切り替えを行う
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
                if (OVRInput.GetDown(OVRInput.RawButton.B))//カメラの切り替えを行う
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


       /* if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            mode = 1;
            changemenu = 0;
            Player.ControllSwitch = 0;
            Time.timeScale = 0;
        }
        if (Input.GetKey(KeyCode.P))
        {
            mode = 0;
            Player.ControllSwitch = 1;
            Time.timeScale = 1.0f;
        }*/

        if(mode == 1)
        {
            status.SetActive(false);
            OptionMenu.SetActive(true);
            sound.SetActive(false);
        }
        else
        {
            status.SetActive(true);
            OptionMenu.SetActive(false);
            sound.SetActive(false);


        }
    }
}
