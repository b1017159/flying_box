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
        //Debug.Log(position);
        //Debug.Log(rotation);

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

    public void MoveObject(int reverse = 1)
    {
        //Debug.Log(position);
        transform.DOMove(new Vector3(positionX, reverse*positionY, positionZ), AnimationTime).SetRelative();
        return;
    }

    public void RotateObject()
    {
        //Debug.Log(rotation);
        transform.DORotate(new Vector3(rotateX, rotateY, rotateZ), AnimationTime).SetRelative();
        return;
    }

}
