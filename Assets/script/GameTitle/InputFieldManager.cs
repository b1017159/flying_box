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
                //text.text = inputField.text;
        }

        void Update()
        {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                        SceneManager.LoadScene("GameTitle");
                }
        }

        //入力された名前情報を読み取ってコンソールに出力する関数
        public void SetInputName()
        {
                inputField.DeactivateInputField();
                //確認画面に移動

                //InputFieldからテキスト情報を取得する
                name = inputField.text;
                Debug.Log(name);

                //テキストにinputFieldの内容を反映
                text.text = inputField.text;

                if (inputField.text !=　 "")
                {
                        SceneManager.LoadScene("NameEnter");
                }
        }

        public static string GetName()
        {
                return name;
        }
}
