using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ranking : MonoBehaviour
{
    private double score;
    // Start is called before the first frame update
    void Start()
    {
        score = Player.scoredata;
        Scene loadscene = SceneManager.GetActiveScene();
        if (loadscene.name == "Ranking")
        {
            score = 0;
        }
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
        //100を魚の大きさにする
    }

    // Update is called once per frame
    void Update()
    {

    }
}
