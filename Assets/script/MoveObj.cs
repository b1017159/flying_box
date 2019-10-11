using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveObj : MonoBehaviour
{
    public bool startMoveEnable = false;
    public bool startRotateEnable = false;
    public float positionX = 0.0f;
    public float positionY = 0.0f;
    public float positionZ = 0.0f;
    public float rotateX = 0.0f;
    public float rotateY = 0.0f;
    public float rotateZ = 0.0f;
    public float AnimationTime = 2.0f;

    private Vector3 position;
    private Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
        rotation = this.transform.eulerAngles;

        if (startMoveEnable)
        {
            MoveObject();
        }
        if (startRotateEnable)
        {
            RotateObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveObject()
    {
        Debug.Log(position);
        transform.DOMove(new Vector3(positionX, positionY, positionZ), AnimationTime).SetRelative();
    }

    public void RotateObject()
    {
        Debug.Log(rotation);
        transform.DORotate(new Vector3(rotateX, rotateY, rotateZ), AnimationTime).SetRelative();
    }

    public void ReturnObject()
    {
        this.transform.position = position;
        this.transform.eulerAngles = rotation;
    }
}
