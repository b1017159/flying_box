using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Text.RegularExpressions;

public class ShowDetail : MonoBehaviour
{
    private Texture item;
    private Texture detail;
    private bool flag;
    private bool wait;
    private float positonY;
    private List<int> awake;
    private List<Transform> ch;
    // Start is called before the first frame update
    void Start()
    {
        item = gameObject.GetComponent<MeshRenderer>().material.GetTexture("_MainTex");
        detail = Resources.Load<Texture>("ZukanDetail/" + gameObject.GetComponent<MeshRenderer>().material.GetTexture("_MainTex").name);
        flag = true;
        wait = false;
        awake = new List<int>();
        ch = gameObject.transform.parent.GetComponent<ShowItems>().GetChildren();
        StartCoroutine("SetPositionY");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowDetailItem()
    {
        if (wait)
        {
            return;
        }
        wait = true;
        int str = int.Parse(Regex.Replace(gameObject.name, @"[^0-9]", ""));
        if (flag)
        {
            for (int i = 0; i < ch.Count; i++)
            {
                if (ch[i].gameObject.activeInHierarchy)
                {
                    if (i != str)
                    {
                        awake.Add(ch.IndexOf(ch[i]));
                        ch[i].DOScale(new Vector3(-0.8f, -1.0f), 0.2f).SetRelative();
                    }
                }
            }
            transform.DOScale(new Vector3(0.4f, 0.5f), 0.2f).SetRelative();
            if (positonY > 1.0f)
            {
                transform.DOMove(new Vector3(-1.5f, -3.5f, 0.0f), 0.2f).SetRelative();
            }
            else
            {
                transform.DOMove(new Vector3(-1.5f, 0.0f, 0.0f), 0.2f).SetRelative();
            }
            flag = false;
        }
        else
        {
            for (int i = 0; i < awake.Count; i++)
            {
                ch[awake[i]].DOScale(new Vector3(0.8f, 1.0f), 0.2f).SetRelative();
            }
            awake.RemoveRange(0, awake.Count);
            transform.DOScale(new Vector3(-0.4f, -0.5f), 0.2f).SetRelative();
            if (positonY > 1.0f)
            {
                transform.DOMove(new Vector3(1.5f, 3.5f, 0.0f), 0.2f).SetRelative();
            }
            else
            {
                transform.DOMove(new Vector3(1.5f, -0.0f, 0.0f), 0.2f).SetRelative();
            }
            flag = true;
        }
        StartCoroutine("WaitingTime");
    }
    IEnumerator SetPositionY()
    {
        yield return new WaitForSeconds(1.0f);
        positonY = transform.position.y;
    }
    IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(0.2f);
        wait = false;
    }
}
