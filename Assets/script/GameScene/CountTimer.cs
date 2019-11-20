using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountTimer : MonoBehaviour
{
    //　トータル制限時間
    private float totalTime;
    //　制限時間（分)
    private int minute;
    //　制限時間（秒）
    private float seconds;
    //　前回Update時の秒数
    private float oldSeconds;
    public GameObject Timer;
    private GameObject FPS;　//一人称カメラ
    private GameObject TPS; //三人称カメラ

    public static int signal = 3;

    private int CamerasigCT;
    

    void Start()
    {
        FPS = GameObject.Find("First_person");
        TPS = GameObject.Find("Third_person");
        minute = Player.minutedata;
        seconds = Player.secondsdata;
        totalTime = Player.totaltimedata;
        oldSeconds = 0f;
        CamerasigCT = Player.camerasig;
    }

    void Update()
    {
        //　タイマー表示用UIテキストに時間を表示する
        minute = Player.minutedata;
        seconds = Player.secondsdata;
        totalTime = minute * 60 + seconds;
        //　タイマー表示用UIテキストに時間を表示する
        if ((int)seconds != (int)oldSeconds)
        {
            Timer.GetComponent<TextMesh>().text = "Time:" + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;

        //　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
        if (totalTime <= 0f)
        {
            Scene loadscene = SceneManager.GetActiveScene();
            Debug.Log(loadscene.name);
       
           
                //Debug.Log(signal);
                if (loadscene.name == "GameStage1")
                {
                     SceneManager.LoadScene("GameStage2");
                    if (CamerasigCT==1)
                    {
                        signal = 1;
                    }
                    else if (CamerasigCT == 3)
                    {
                        signal = 3;
                    }

                }
                if (loadscene.name == "GameStage2")
                {
                     SceneManager.LoadScene("GameStage3");
                    if (CamerasigCT == 1)
                    {
                        signal = 1;
                    }
                    else if (CamerasigCT == 3)
                    {
                        signal = 3;
                    }
                }
                if (loadscene.name == "GameStage3")
                {
                     SceneManager.LoadScene("ClearScene");
                    if (CamerasigCT == 1)
                    {
                        signal = 1;
                    }
                    else if (CamerasigCT == 3)
                    {
                        signal = 3;
                    }
                }
            

        }
    }
}
