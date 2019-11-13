using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameGet : MonoBehaviour
{

    public Text targetText;
    public string username;

    // Start is called before the first frame update
    void Start()
    {
        username = InputName.GetName();

        this.targetText = this.GetComponent<Text>();

        this.targetText.text = username;
       
    }


}
