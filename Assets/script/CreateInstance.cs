using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInstance : MonoBehaviour
{
    [SerializeField]
    Transform parent;
    [SerializeField]
    private GameObject item;

    public int num_item = 5;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < num_item; i++)
        {
            GameObject obj;
            obj = Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity, parent) as GameObject;    
            obj.transform.Rotate(0.0f, i*48.0f, 0.0f);
            if(i >= 5)
            {
                obj.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
