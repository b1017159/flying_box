using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour
{

        // Update is called once per frame
        void Update()
        {
                if (Input.GetKeyDown(KeyCode.B)||Input.GetKeyDown ("joystick button 1")||Input.GetKeyDown ("joystick button 0"))
                {
                        SceneManager.LoadScene("GameTitle");
                }
        }
}
