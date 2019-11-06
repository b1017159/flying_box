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
        inputField.ActivateInputField();

        //InputFieldコンポーネントを取得
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        text = text.GetComponent<Text>();

        //テキストにinputFieldの内容を反映
        text.text = inputField.text;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            SceneManager.LoadScene("GameTitle");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputField.DeactivateInputField();
        }
       
    }

    //入力された名前情報を読み取ってコンソールに出力する関数
    public void SetInputName()
    {
        //InputFieldからテキスト情報を取得する
        name = inputField.text;
        Debug.Log(name);

        //テキストにinputFieldの内容を反映
        text.text = inputField.text;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("NameEnter");
        }
    }

    public static string GetName()
    {
        return name;
    }
}