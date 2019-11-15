using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
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
            SceneManager.LoadScene("Ruru1Comp");
        }

        if(OVRInput.Get(OVRInput.RawButton.A))
        {
            SceneManager.LoadScene("Ruru1Comp");
        }

    }
}
