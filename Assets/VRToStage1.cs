﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRToStage1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("GameStage1");
        }

        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            SceneManager.LoadScene("GameStage1");
        }

    }
}
