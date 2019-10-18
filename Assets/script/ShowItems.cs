using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowItems : MonoBehaviour
{
    //[SerializeField] private GameObject parentObject;
    private float delay_time;
    private List<Transform> childObjects;
    private int num_item, pin;
    //private float checkpoint, headposition, endposition;
    private float mouseInputed = 0.0f;
    [SerializeField] public float wheelSpeed = 0.1f;
    public float rotatespeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        pin = 0;
        delay_time = GetComponent<MoveObj>().AnimationTime;
        num_item = GetComponent<CreateInstance>().num_item;
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
                int n = 0;
                if (mouseInputed > 1.0f) n = 1;
                else n = 0;

                for(int i = 0; i < num_item; i++)
                {
                    childObjects[i].DORotate(new Vector3(0.0f, (n + i)*48.0f, 0.0f), 0.1f);
                }
                mouseInputed = 0.0f;
            }
            //マウスウィール入力
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            if (System.Math.Abs(scrollWheel) > 0)
            {
                MouseWheel(scrollWheel);
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
            string log = child.gameObject.name.ToString();
            Debug.Log(log);
        }
    }
}
