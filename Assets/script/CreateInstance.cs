using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInstance : MonoBehaviour
{
    [SerializeField]
    Transform parent;
    [SerializeField]
    private GameObject item;

    private List<Transform> childObjects = new List<Transform>();
    public int num_item = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < num_item; i++)
        {
            GameObject obj;
            obj = Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity, parent) as GameObject;
            obj.gameObject.name += i.ToString();
            obj.gameObject.transform.Rotate(0.0f, 48.0f * i, 0.0f);
            childObjects.Add(obj.transform);
            if (i > 4) obj.gameObject.SetActive(false);
            
        }
        GetComponent<ShowItems>().SetChild(childObjects);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //getterメソッド
    public List<Transform> GetChildren() { return childObjects; }
    //public float GetEulerAnglesY() { return transform.eulerAngles.y; }
    //public void SetEulerAnglesY(float y) { transform.eulerAngles.y = y; }
}
