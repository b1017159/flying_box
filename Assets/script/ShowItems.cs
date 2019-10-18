using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItems : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;

    [SerializeField] public float wheelSpeed = 1f;
    public float rotatespeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0.0f, rotatespeed * Time.deltaTime, 0.0f));
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if(System.Math.Abs(scrollWheel) > 0)
        {
            MouseWheel(scrollWheel);
        }
    }

    private void MouseWheel(float delta)
    {
        this.transform.Rotate(new Vector3(0.0f, delta * wheelSpeed, 0.0f));
        return;
    }
}
