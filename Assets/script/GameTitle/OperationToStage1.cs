using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OperationToStage1 : MonoBehaviour
{
    public AudioClip SoundEffect;
    AudioSource audioSource;
    private void Awake()
    {
        int DestroyCheck = FindObjectsOfType<OperationToStage1>().Length;
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
        if (loadscene.name == "Operation")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                audioSource.PlayOneShot(SoundEffect);
                SceneManager.LoadScene("GameStage1");
            }
            
        }
    }
   
       

   
}
