using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowItems : MonoBehaviour
{
    //[SerializeField] private GameObject parentObject;
    private float delay_time;
    private List<Transform> childObjects;
    private int pin;
    //private float checkpoint, headposition, endposition;
    private float mouseInputed = 0.0f;
    [SerializeField] public float wheelSpeed = 1.0f;
    public float rotatespeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        delay_time = GetComponent<MoveObj>().AnimationTime;
        pin = GetComponent<CreateInstance>().pin;        
    }

    // Update is called once per frame
    void Update()
    {
        if(delay_time > 0.0f)     
        {
            delay_time -= Time.deltaTime * 1.0f;
        }
        else
        {
            if (System.Math.Abs(mouseInputed) > 1.0f)
            {
                int n;
                if (mouseInputed > 1.0f) n = 1;
                else n = -1;

                if(n == 1)
                {
                    childObjects[pin - 1].gameObject.SetActive(false);
                    Transform tf = childObjects[childObjects.Count - 1];
                    childObjects.RemoveAt(childObjects.Count - 1);
                    childObjects.Insert(0, tf);
                    childObjects[0].gameObject.SetActive(true);
                    childObjects[0].DORotate(new Vector3(0.0f, -48.0f, 0.0f), 0.0f);
                } else if (n == -1)
                {
                    childObjects[0].gameObject.SetActive(false);
                    Transform tf = childObjects[0];
                    childObjects.RemoveAt(0);
                    childObjects.Add(tf);
                    childObjects[pin - 1].gameObject.SetActive(true);
                    childObjects[pin - 1].DORotate(new Vector3(0.0f, 48.0f * pin, 0.0f), 0.0f);
                }
                for(int i = 0; i < pin; i++)
                {
                    childObjects[i].DORotate(new Vector3(0.0f, 48.0f * n, 0.0f), 0.1f).SetRelative();
                }
                mouseInputed = 0.0f;
                delay_time = 0.01f;
            } else
            {
                //マウスウィール入力
                float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
                if (System.Math.Abs(scrollWheel) > 0)
                {
                    MouseWheel(scrollWheel);
                }
            }
   
        }
    }

    private void MouseWheel(float delta)
    {
        mouseInputed += wheelSpeed * delta;
    }

    public void SetChild(List<Transform> ch)
    {
        childObjects = ch;
        foreach (Transform child in childObjects)
        {
            string log = child.gameObject.name;
            Debug.Log(log);
        }
    }
}
