using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItems : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    private List<Transform> childObjects = new List<Transform>(12);
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform childTranstorm in parentObject.transform)
        {
            childObjects.Add(childTranstorm);
        }
        foreach(Transform child in childObjects)
        {
            Debug.Log(child.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
