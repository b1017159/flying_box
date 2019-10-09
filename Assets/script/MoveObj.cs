using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveObj : MonoBehaviour
{
    public bool startEnable = false;
    public float positionX = 0.0f;
    public float positionY = 0.0f;
    public float positionZ = 0.0f;
    public float AnimationTime = 2.0f;

    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;

        if (startEnable)
        {
            MoveObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveObject()
    {
        Debug.Log(position);
        transform.DOMove(new Vector3(positionX, positionY, positionZ), AnimationTime);
    }

    public void ReturnObject()
    {
        this.transform.position = position;
    }
}
