using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowItems : MonoBehaviour
{
    private List<Transform> children, ch1, ch2;
    private int pin;
    private float delay_time;
    private float mouseInputed = 0.0f;

    public float wheelSpeed = 1.0f;
    public bool separate = false;
    void Start()
    {
        delay_time = GetComponent<MoveObj>().AnimationTime;
        pin = GetComponent<CreateInstance>().pin;
        if (separate)
        {
            StartCoroutine(SeparateChildren());
        }
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
                if (separate)
                {
                    RotateChildren(n,ch1);
                    RotateChildren(n, ch2);
                }
                else
                {
                    RotateChildren(n, children);
                }

                mouseInputed = 0.0f;
                delay_time = 0.3f;
            }    
        }
        //マウスウィール入力
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (System.Math.Abs(scrollWheel) > 0)
        {
            MouseWheel(scrollWheel);
        }
    }

    private void MouseWheel(float delta)
    {
        mouseInputed += wheelSpeed * delta;
    }

    private void RotateChildren(int n, List<Transform> list)
    {
        if (n == 1)
        {
            list[pin - 1].gameObject.SetActive(false);
            Transform tf = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            list.Insert(0, tf);
            list[0].gameObject.SetActive(true);
            list[0].DORotate(new Vector3(0.0f, -48.0f, 0.0f), 0.0f);
        }
        else if (n == -1)
        {
            list[0].gameObject.SetActive(false);
            Transform tf = list[0];
            list.RemoveAt(0);
            list.Add(tf);
            list[pin - 1].gameObject.SetActive(true);
            list[pin - 1].DORotate(new Vector3(0.0f, 48.0f * pin, 0.0f), 0.0f);
        }
        for (int i = 0; i < pin; i++)
        {
            list[i].DORotate(new Vector3(0.0f, 48.0f * n, 0.0f), 0.3f).SetRelative();
        }
    }

    public void SetChildren(List<Transform> chr)
    {
        children = chr;
        foreach (Transform child in children)
        {
            string log = child.gameObject.name;
            Debug.Log(log);
        }
    }

    private IEnumerator SeparateChildren()
    {
        yield return new WaitForSeconds(0.1f);
        ch1 = children.GetRange(0, children.Count / 2);
        ch2 = children.GetRange(children.Count / 2, children.Count - (children.Count / 2));
        Vector3 pos;
        for (int i = 0; i < ch1.Count; i++)
        {
            ch1[i].gameObject.SetActive(true);
            pos = ch1[i].transform.position;
            pos.y += 2.0f;
            ch1[i].transform.position = pos;
            
            if (i >= pin) ch1[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < ch2.Count; i++)
        {
            ch2[i].gameObject.SetActive(true);
            pos = ch2[i].transform.position;
            pos.y -= 1.5f;
            ch2[i].transform.position = pos;
            
            if (i >= pin) ch2[i].gameObject.SetActive(false);
        }
        Debug.Log(ch1.Count);
        Debug.Log(ch2.Count);
    }
}
