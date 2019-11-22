using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
        private double score;
        public GameObject scoreText; // スコアの UI
        public static double scoredata = 0; // スコアデータ
        private float size = 1.2f; // 巨大化
        // Start is called before the first frame update
        TextMesh text;
        void Start()
        {
                score = Player.scoredata;
                SetCountText();
                text= this.GetComponent<TextMesh>();
        }

        // Update is called once per frame
        void Update()
        {
                if(Player.updown<-15) {
                        text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                }else{
                        text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
                score = Player.scoredata;
                scoredata = score;
                SetCountText();
        }

        // UI の表示を更新する
        void SetCountText()
        {
                // スコアの表示を更新
                scoreText.GetComponent<TextMesh>().text = "あなたのサイズ: "  + score.ToString() + "cm";
        }
        public static double GetScore()
        {
                return scoredata;
        }
}
