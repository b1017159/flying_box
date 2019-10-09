using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShowScore : MonoBehaviour
{
    private TextMesh Result;

    int score;


    // Start is called before the first frame update
    void Start()
    {
        Result = GetComponentInChildren<TextMesh>();

        score = Player.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        Result.text ="あなたのスコア　"+score+"m";
       
        if (Input.GetKey(KeyCode.Space))
        {
            Scene loadscene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene("GameStage1");   
        }

    }

}
