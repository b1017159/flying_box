using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameToVR : MonoBehaviour
{
    void Update()
    {
        GameObject obj3 = GameObject.Find("NOText");
        if (Input.GetKeyDown(KeyCode.Y) && obj3.activeInHierarchy)
        {
            SceneManager.LoadScene("VRSetting");
        }

        if (Input.GetKeyDown(KeyCode.N) && obj3.activeInHierarchy)
        {
            SceneManager.LoadScene("Name");
        }
    }
}
