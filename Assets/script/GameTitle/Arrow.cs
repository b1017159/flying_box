using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Arrow : MonoBehaviour
{
        int zyouge=0;//メニュー画面で上下移動するためのフラグ
        int changemenu=0;//矢印の位置決め
        RectTransform rect;//
        AudioSource audioSource;
        public AudioClip SoundEffect;//選択肢を決めたときの選択音
        GameObject dicision;//決定キーを押すため他のゲームオブジェクトからAudioorceを発動
        void Start()
        {
                rect = GetComponent <RectTransform> ();
                audioSource = GetComponent<AudioSource>();
                dicision=GameObject.Find ("LoadScene");//gameObjectが削除されるため毎回探す
        }
        void Update()
        {
                float hori = Input.GetAxis ("Horizontal");
                float vert = Input.GetAxis ("Vertical");
                if(vert != 0) {
                        if(vert>0&&zyouge<0) zyouge=0;
                        if(vert<0&&zyouge>0) zyouge=0;
                }else{//カーソルが高速移動するため制限をかける
                        zyouge=0;
                }
                if ((Input.GetKeyDown(KeyCode.DownArrow)||(vert<-0.75&&zyouge==0)))
                {
                        changemenu += 1;//上下移動
                        zyouge--;
                        if(changemenu==3) changemenu=0;
                        audioSource.PlayOneShot(SoundEffect);
                }
                if ((Input.GetKeyDown(KeyCode.UpArrow)||(vert>0.75&&zyouge==0)))
                {
                        changemenu -= 1;
                        zyouge++;
                        if(changemenu==-1) changemenu=2;
                        audioSource.PlayOneShot(SoundEffect);
                }
                Vector3 tempSpear = rect.localPosition;
                if(changemenu==0) tempSpear.y =-40f;
                if(changemenu==1) tempSpear.y =-150f;
                if(changemenu==2) tempSpear.y =-250f;
                rect.localPosition=tempSpear;
                Scene loadscene = SceneManager.GetActiveScene();
                if (loadscene.name == "GameTitle")
                {
                        TitleSceneManager target = dicision.GetComponent<TitleSceneManager>();
                        if (changemenu==0&&Input.GetKeyDown ("joystick button 1"))
                        {
                                SceneManager.LoadScene("Name");
                                target.sound();//TitleSceneManagerのSEを使う
                        }
                        if (changemenu==2&&Input.GetKeyDown ("joystick button 1"))
                        {
                                SceneManager.LoadScene("TopRanking");
                                target.sound();
                        }
                }
        }
}
