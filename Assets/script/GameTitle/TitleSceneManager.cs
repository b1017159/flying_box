
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
        public AudioClip SoundEffect;
        AudioSource audioSource;
        private void Awake()
        {
                int DestroyCheck = FindObjectsOfType<TitleSceneManager>().Length;
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
                if (loadscene.name == "GameTitle")
                {
                        if (Input.GetKeyDown(KeyCode.A))
                        {
                                audioSource.PlayOneShot(SoundEffect);
                                SceneManager.LoadScene("Name");
                        }
                        if (Input.GetKeyDown(KeyCode.C))
                        {
                                audioSource.PlayOneShot(SoundEffect);
                                SceneManager.LoadScene("TopRanking");
                        }
                }

        }
        public void sound(){
                audioSource.PlayOneShot(SoundEffect);
        }
}
