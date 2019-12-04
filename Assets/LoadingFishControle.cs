using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingFishControle : MonoBehaviour
{
    public GameObject LoadingFish1;
    public GameObject LoadingFish2;
    public GameObject LoadingFish3;
    public GameObject LoadingFish4;
    public GameObject LoadingFish5;

    // Start is called before the first frame update
    void Start()
    {
        LoadingFish2.SetActive(false);
        LoadingFish3.SetActive(false);
        LoadingFish4.SetActive(false);
        LoadingFish5.SetActive(false);
        Invoke("R", 1);
        Invoke("I", 2);
        Invoke("K", 3);
        Invoke("U", 4);
    }

    // Update is called once per frame
    
    void R()
    {
        LoadingFish2.SetActive(true);  
    }

    void I()
    {
        LoadingFish3.SetActive(true);
    }

    void K()
    {
        LoadingFish4.SetActive(true);
    }

    void U()
    {
        LoadingFish5.SetActive(true);
    }
}
