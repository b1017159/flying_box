using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDetail : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDetailItem()
    {
        if (obj.gameObject.activeInHierarchy)
        {
            obj.SetActive(false);
        }
        else
        {

            obj.SetActive(true);
        }
    }
}
