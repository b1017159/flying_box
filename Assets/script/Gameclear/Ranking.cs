using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
        private double score;
        // Start is called before the first frame update
        void Start()
        {
                score = Player.scoredata;
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score);
                //100を魚の大きさにする
        }

        // Update is called once per frame
        void Update()
        {

        }
}
