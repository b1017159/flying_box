using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToOption : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (GameObject.Find("ActiveOnOff"))
            {
                GameObject obj = GameObject.Find("ActiveOnOff");
                Destroy(obj);
            }
            SceneManager.LoadScene("LightMenu");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("CameraMenu");
        }
    }
}
