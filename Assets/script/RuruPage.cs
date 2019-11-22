using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
public class RuruPage : MonoBehaviour
{
    public AudioClip SoundEffect;
    public AudioClip gamestart;
    AudioSource audioSource;
    private void Awake()
    {
        int DestroyCheck = FindObjectsOfType<RuruPage>().Length;
        if (DestroyCheck > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        Scene loadscene = SceneManager.GetActiveScene();
        if (loadscene.name == "Ruru1Comp")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru2Comp");
            }
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru2Comp");
            }
        }
        if (loadscene.name == "Ruru2Comp")
        {
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru3Comp");
            }

            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru1Comp");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru3Comp");
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru1Comp");
            }
        }
        if (loadscene.name == "Ruru3Comp")
        {
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru4Comp");
            }

            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru2Comp");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru4Comp");
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru2Comp");
            }
        }
        if (loadscene.name == "Ruru4Comp")
        {
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Operation");
            }
            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru3Comp");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Operation");
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Ruru3Comp");
            }
        }
        if (loadscene.name == "Operation")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                audioSource.PlayOneShot(gamestart);
                SceneManager.LoadScene("GameStage1");
            }

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                audioSource.PlayOneShot(gamestart);
                SceneManager.LoadScene("GameStage1");
            }
        }

    }
}
