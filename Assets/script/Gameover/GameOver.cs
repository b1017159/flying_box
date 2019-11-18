using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public AudioClip audioClip3;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.clip = audioClip3;
                audioSource.Play ();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            SceneManager.LoadScene("GameStage1");
            Player.scoredata = 30;
            Player.sizedata = 3f;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            SceneManager.LoadScene("GameMenu");
            Player.scoredata = 30;
            Player.sizedata = 3f;
        }
    }
}
