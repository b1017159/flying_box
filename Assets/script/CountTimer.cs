using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountTimer : MonoBehaviour
{

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
    public GameObject Timer;

    void Start()
    {
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
    }

    void Update()
    {
        //　制限時間が0秒以下なら何もしない
        if (totalTime <= 0f)
        {
            return;
        }
        //　一旦トータルの制限時間を計測；
        totalTime = minute * 60 + seconds;
        totalTime -= Time.deltaTime;

        //　再設定
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        //　タイマー表示用UIテキストに時間を表示する
        if ((int)seconds != (int)oldSeconds)
        {
             Timer.GetComponent<TextMesh>().text = "Time:" + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        
          //  Timer.text = "Time:" + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
        //　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
        if (totalTime <= 0f)
        {
            Scene loadscene = SceneManager.GetActiveScene();
            Debug.Log(loadscene.name);
            if (loadscene.name == "GameStage1")
            {
                SceneManager.LoadScene("GameStage2");
            }
            if (loadscene.name == "GameStage2")
            {
                SceneManager.LoadScene("GameStage3");
            }


        }
    }
}
