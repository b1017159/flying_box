using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputFieldManager : MonoBehaviour
{
    //InputFieldを格納するための変数
    public InputField inputField;
    public Text text;
    public static string name ="あなた";

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクト非表示
        GameObject obj9 = GameObject.Find("EnterText");
        obj9.SetActive(false);

        GameObject obj2 = GameObject.Find("YESText");
        obj2.SetActive(false);

        GameObject obj3 = GameObject.Find("NOText");
        obj3.SetActive(false);

        GameObject obj4 = GameObject.Find("NameText");
        obj4.SetActive(false);

        //InputFieldコンポーネントを取得
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        text = text.GetComponent<Text>();
    }

    //入力された名前情報を読み取ってコンソールに出力する関数
    public void GetInputName()
    {
        //InputFieldからテキスト情報を取得する
        name = inputField.text;
        Debug.Log(name);

        //テキストにinputFieldの内容を反映
        text.text = inputField.text;
    }

    public static string GetName()
    {
        return name;
    }

    //テキストを表示するかの関数
    public void TextOnOff()
    {
        GameObject obj10 = GameObject.Find("InputField");
        GameObject obj11 = obj10.transform.Find("EnterText").gameObject;
        obj11.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject obj6 = GameObject.Find("InputField");
            obj6.SetActive(false);
            GameObject obj5 = GameObject.Find("YESNO");
            GameObject obj2 = obj5.transform.Find("YESText").gameObject;
            GameObject obj3 = obj5.transform.Find("NOText").gameObject;
            GameObject obj4 = obj5.transform.Find("NameText").gameObject;


            obj2.SetActive(true);
            obj3.SetActive(true);
            obj4.SetActive(true);

        }
    }
}