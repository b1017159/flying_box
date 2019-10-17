using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nekoCricked : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickAct()
    {

        Debug.Log("タッチされたにゃー");
        if (gameObject.activeInHierarchy)
        {
            MoveObj mo = gameObject.GetComponent<MoveObj>();
            
            mo.MoveObject(-1);
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            MoveObj mo = gameObject.GetComponent<MoveObj>();
            mo.MoveObject();
        }

    }
}