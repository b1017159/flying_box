﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItems : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    private List<Transform> childObjects = new List<Transform>(12);

    [SerializeField] public float wheelSpeed = 1f;
    public float rotatespeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //はじめに子オブジェクトをすべて取得する｡
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
        this.transform.Rotate(new Vector3(0.0f, rotatespeed * Time.deltaTime, 0.0f));
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if(scrollWheel != 0.0f)
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
