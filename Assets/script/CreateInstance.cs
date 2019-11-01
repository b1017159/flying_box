using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInstance : MonoBehaviour
{
    [SerializeField]
    Transform parent;
    [SerializeField]
    private GameObject item;

    private List<Transform> children = new List<Transform>();
    public int pin = 5;

    // Start is called before the first frame update
    void Start()
    {
        Texture[] images = Resources.LoadAll<Texture>("SakanaZukan/");

        for (int i = 0; i < images.Length; i++)
        {
            GameObject obj;
            obj = Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity, parent) as GameObject;
            obj.gameObject.name += i.ToString();
            obj.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", images[i]);
            obj.gameObject.transform.Rotate(0.0f, 48.0f * (i % (images.Length / 2)), 0.0f);

            children.Add(obj.transform);
            if (i >= pin) obj.gameObject.SetActive(false);

        }
        GetComponent<ShowItems>().SetChildren(children);
    }
    // Update is called once per frame
    void Update()
    {

    }
    //getterメソッド
    public List<Transform> GetChildren() { return children; }
}
