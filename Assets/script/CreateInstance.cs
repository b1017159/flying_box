using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInstance : MonoBehaviour
{
    [SerializeField]
    Transform parent;
    [SerializeField]
    private GameObject item;

    private Dictionary<int, Transform> childObjects = new Dictionary<int, Transform>(16);
    public int num_item = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < num_item; i++)
        {
            GameObject obj;
            obj = Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity, parent) as GameObject;
            obj.gameObject.name += i.ToString();
            childObjects.Add(i, obj.transform);
            Debug.Log(childObjects[i].gameObject.name);
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
    //getterメソッド
    public Dictionary<int, Transform> getChildren() { return this.childObjects; }
}
