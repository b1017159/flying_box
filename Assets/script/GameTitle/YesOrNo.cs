﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YesOrNo : MonoBehaviour
{
        public AudioClip SoundEffect;
        AudioSource audioSource;
        private void Awake()
        {
                int DestroyCheck = FindObjectsOfType<YesOrNo>().Length;
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
                if (loadscene.name == "NameEnter")
                {
                        if (Input.GetKeyDown(KeyCode.Y)||Input.GetKeyDown ("joystick button 1"))
                        {
                                audioSource.PlayOneShot(SoundEffect);
                                SceneManager.LoadScene("Ruru");
                        }

                        if (Input.GetKeyDown(KeyCode.N)||Input.GetKeyDown ("joystick button 0"))
                        {
                                audioSource.PlayOneShot(SoundEffect);
                                SceneManager.LoadScene("Name");
                        }
                }
        }
}
