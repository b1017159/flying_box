using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameSceneManager : MonoBehaviour
{
    void Update()
    {
        GameObject obj3 = GameObject.Find("NOText");
        if (Input.GetKeyDown(KeyCode.Y) && obj3.activeInHierarchy)
        {
            SceneManager.LoadScene("Ruru");
        }

        if (Input.GetKeyDown(KeyCode.N) && obj3.activeInHierarchy)
        {
            SceneManager.LoadScene("Name");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("GameTitle");
        }
    }
}
