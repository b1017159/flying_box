using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
public class RuruPage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(OVRInput.GetDown(OVRInput.RawButton.A))
        {
            SceneManager.LoadScene("Ruru2Comp");
        }

        /*if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("GameStage1");
        }*/
    }
}
