using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP3 : MonoBehaviour
{
        public AudioClip sound1;//食べる
        public AudioClip sound2;//ダメージ
        public AudioClip sound3;
        public int Mswich;//０:BGM 1:爆発 2:アイテム
        private AudioSource[] sources;
        void Start()
        {
                Mswich=0;
                sources = GetComponents<AudioSource>();
                sources[0].Stop();
        }

        // Update is called once per frame
        void Update()
        {
                if(Mswich!=4) {
                        SE(Mswich);
                }
        }
        public void SE(int se){
                if(se==1) {
                        sources[1].PlayOneShot(sound1);
                        Debug.Log("音なるよ");
                        //sources[0].Stop();
                        Mswich =4;
                }
                if(se==2) {
                        sources[1].PlayOneShot(sound2);
                        Debug.Log("音なるよ");
                        Mswich =4;
                }
                if(se==0) {
                        sources[0].Play();
                        Mswich=4;
                }
        }
}
