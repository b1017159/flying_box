using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YesOrNo : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("VRSetting");
        }

        if (Input.GetKeyDown(KeyCode.N))
            SceneManager.LoadScene("Name");
    }
}
