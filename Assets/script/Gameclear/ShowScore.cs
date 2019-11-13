﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShowScore : MonoBehaviour
{
    private TextMesh Result;

    double score;

    string username;


    // Start is called before the first frame update
    void Start()
    {
        Result = GetComponentInChildren<TextMesh>();

        score = ScoreText.GetScore();

        username = InputFieldManager.GetName();
    }

    // Update is called once per frame
    void Update()
    {
      
        Result.text = username+"のスコア　"+score+"m";

        Scene loadscene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.A))
        {
                SceneManager.LoadScene("GameStage1");
            Player.scoredata = 30;
            Player.sizedata = 3f;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("GameTitle");
            Player.scoredata = 30;
            Player.sizedata = 3f;
        }


    }

}
