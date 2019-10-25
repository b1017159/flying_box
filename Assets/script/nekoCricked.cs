using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nekoCricked : MonoBehaviour
{
    //public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAct()
    {
        //SceneManager.LoadScene("GameTitle");
        Debug.Log("タッチされたにゃー");
        GameObject obj = transform.parent.gameObject;
        obj.GetComponent<ShowDetail>().ShowDetailItem();
    }
}