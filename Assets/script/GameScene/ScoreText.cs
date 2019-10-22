using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private int score;
    public GameObject scoreText; // スコアの UI
    public static int scoredata = 0; // スコアデータ
    private float size = 1.2f; // 巨大化
    // Start is called before the first frame update
    void Start()
    {
        score = Player.scoredata;

        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {

        score = Player.scoredata;
        scoredata = score;
        SetCountText();
    }

    // UI の表示を更新する
    void SetCountText()
    {
        // スコアの表示を更新
        scoreText.GetComponent<TextMesh>().text = "Count: " + score.ToString();
    }
    public static int GetScore()
    {
        return scoredata;
    }
}