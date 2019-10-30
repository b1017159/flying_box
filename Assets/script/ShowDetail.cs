using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowDetail : MonoBehaviour
{
    private Texture item;
    private Texture detail;
    private bool flag;
    private float positonY;
    
    // Start is called before the first frame update
    void Start()
    {
        item = gameObject.GetComponent<MeshRenderer>().material.GetTexture("_MainTex");
        detail = Resources.Load<Texture>("ZukanDetail/" + gameObject.GetComponent<MeshRenderer>().material.GetTexture("_MainTex").name);
        flag = true;
        StartCoroutine("SetPositionY");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowDetailItem()
    {
        Debug.Log(positonY);
        if (flag)
        {
            gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", detail);
            transform.DOScale(new Vector3(0.5f, 0.5f), 0.2f).SetRelative();
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
            gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", item);
            transform.DOScale(new Vector3(-0.5f, -0.5f), 0.2f).SetRelative();
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
    }
    IEnumerator SetPositionY()
    {
        yield return new WaitForSeconds(1.0f);
        positonY = transform.position.y;
    }
}
