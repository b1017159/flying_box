using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("GameStage1");
            Player.scoredata = 30;
            Player.sizedata = 3f;
        }
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene("GameTitle");
            Player.scoredata = 30;
            Player.sizedata = 3f;
        }
    }
}
