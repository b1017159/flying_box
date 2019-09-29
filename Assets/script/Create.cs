using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Create : MonoBehaviour
{
    public RectTransform contentRectTransform;
    public Button button;
    private void Start()
    {
        for (int i = 1; i <= 35; i++)
        {
            var obj = Instantiate(button, contentRectTransform);
            obj.GetComponentInChildren<Text>().text = i.ToString();
            //if (i == 1)
            //    obj.GetComponentInChildren<Text>().text = "neko";
        }
    }
}