using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuruPage4 : MonoBehaviour
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
            SceneManager.LoadScene("Operation");
        }
        
        

        if(OVRInput.GetDown(OVRInput.RawButton.B))
        {
            SceneManager.LoadScene("Ruru3Comp");
        }
    }
}
