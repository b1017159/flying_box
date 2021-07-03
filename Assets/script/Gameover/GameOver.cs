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
                if (Input.GetKey(KeyCode.R)||Input.GetKeyDown ("joystick button 1"))
                {
                        Scene loadscene = SceneManager.GetActiveScene();
                        if (loadscene.name == "Stage1 G")
                        {
                                SceneManager.LoadScene("GameStage1");
                        }
                        if (loadscene.name == "Stage2 G")
                        {
                                SceneManager.LoadScene("GameStage2");
                        }
                        if (loadscene.name == "Stage3 G")
                        {
                                SceneManager.LoadScene("GameStage3");
                        }
                        if (loadscene.name == "GameClear")
                        {
                                SceneManager.LoadScene("GameStage1");
                        }

                }
                if (Input.GetKey(KeyCode.T)||Input.GetKeyDown ("joystick button 0"))
                {
                        SceneManager.LoadScene("GameTitle");
                        Player.scoredata = 30;
                        Player.sizedata = 3f;
                        Player.count = 0;
                }
        }
}
