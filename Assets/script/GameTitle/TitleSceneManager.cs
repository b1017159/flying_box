﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class TitleSceneManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("Name");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("Zukan");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("GameMenu");
        }

         
    }
}