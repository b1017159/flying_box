using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuruToOperation : MonoBehaviour
{
    public AudioClip SoundEffect;
    AudioSource audioSource;
    private void Awake()
    {
        int DestroyCheck = FindObjectsOfType<RuruToOperation>().Length;
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
        if (loadscene.name == "Ruru")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("Operation");
            }

        }
    }

}
