using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
public class VRToStage1 : MonoBehaviour
{
    public AudioClip SoundEffect;
    AudioSource audioSource;
    private void Awake()
    {
        int DestroyCheck = FindObjectsOfType<VRToStage1>().Length;
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
    // Update is called once per frame
    void Update()
    {
        Scene loadscene = SceneManager.GetActiveScene();
        if (loadscene.name == "VRsetting")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SceneManager.LoadScene("Ruru1Comp");
                audioSource.PlayOneShot(SoundEffect);
            }

            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                SceneManager.LoadScene("Ruru1Comp");
                audioSource.PlayOneShot(SoundEffect);
            }
        }
    }
}
