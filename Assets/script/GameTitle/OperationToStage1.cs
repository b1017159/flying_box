using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OperationToStage1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("GameStage1");
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SceneManager.LoadScene("GameStage1");
        }
    }
}
