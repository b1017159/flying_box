﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour
{
    public Text textA;
    public static string name = "";
    // Start is called before the first frame update
    public GameObject english; 
    public GameObject japanese;
    public GameObject smallenglish;
    public GameObject da;
    public GameObject pa;
    public GameObject smalltext;

    void Start()
    {
        english.SetActive(false);
        smallenglish.SetActive(false);
    }

    void Update()
    {
        if (name.Length > 8)
        {
            Destory();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("GameTitle");
        }
       
    }

    // Update is called once per frame
    public void ButtonA()
    {
        textA.text += "あ";
        name = textA.text;
    }
    public void ButtonA1()
    {
        textA.text += "い";
        name = textA.text;
    }
    public void ButtonA2()
    {
        textA.text += "う";
        name = textA.text;
    }
    public void ButtonA3()
    {
        textA.text += "え";
        name = textA.text;
    }
    public void ButtonA4()
    {
        textA.text += "お";
        name = textA.text;
    }
    public void ButtonB()
    {
        textA.text += "か";
        name = textA.text;
    }
    public void ButtonB1()
    {
        textA.text += "き";
        name = textA.text;
    }
    public void ButtonB2()
    {
        textA.text += "く";
        name = textA.text;
    }
    public void ButtonB3()
    {
        textA.text += "け";
        name = textA.text;
    }
    public void ButtonB4()
    {
        textA.text += "こ";
        name = textA.text;
    }
    public void ButtonC()
    {
        textA.text += "さ";
        name = textA.text;
    }
    public void ButtonC1()
    {
        textA.text += "し";
        name = textA.text;
    }
    public void ButtonC2()
    {
        textA.text += "す";
        name = textA.text;
    }
    public void ButtonC3()
    {
        textA.text += "せ";
        name = textA.text;
    }
    public void ButtonC4()
    {
        textA.text += "そ";
        name = textA.text;
    }
    public void ButtonD()
    {
        textA.text += "た";
        name = textA.text;
    }
    public void ButtonD1()
    {
        textA.text += "ち";
        name = textA.text;
    }
    public void ButtonD2()
    {
        textA.text += "つ";
        name = textA.text;
    }
    public void ButtonD3()
    {
        textA.text += "て";
        name = textA.text;
    }
    public void ButtonD4()
    {
        textA.text += "と";
        name = textA.text;
    }
    public void ButtonE()
    {
        textA.text += "な";
        name = textA.text;
    }
    public void ButtonE1()
    {
        textA.text += "に";
        name = textA.text;
    }
    public void ButtonE2()
    {
        textA.text += "ぬ";
        name = textA.text;
    }
    public void ButtonE3()
    {
        textA.text += "ね";
        name = textA.text;
    }
    public void ButtonE4()
    {
        textA.text += "の";
        name = textA.text;
    }
    public void ButtonF()
    {
        textA.text += "は";
        name = textA.text;
    }
    public void ButtonF1()
    {
        textA.text += "ひ";
        name = textA.text;
    }
    public void ButtonF2()
    {
        textA.text += "ふ";
        name = textA.text;
    }
    public void ButtonF3()
    {
        textA.text += "へ";
        name = textA.text;
    }
    public void ButtonF4()
    {
        textA.text += "ほ";
        name = textA.text;
    }

    public void ButtonG()
    {
        textA.text += "ま";
        name = textA.text;
    }
    public void ButtonG1()
    {
        textA.text += "み";
        name = textA.text;
    }
    public void ButtonG2()
    {
        textA.text += "む";
        name = textA.text;
    }
    public void ButtonG3()
    {
        textA.text += "め";
        name = textA.text;
    }
    public void ButtonG4()
    {
        textA.text += "も";
        name = textA.text;
    }
    public void ButtonH()
    {
        textA.text += "や";
        name = textA.text;
    }
    public void ButtonH2()
    {
        textA.text += "ゆ";
        name = textA.text;
    }
    public void ButtonH4()
    {
        textA.text += "よ";
        name = textA.text;
    }
    public void ButtonI()
    {
        textA.text += "ら";
        name = textA.text;
    }
    public void ButtonI1()
    {
        textA.text += "り";
        name = textA.text;
    }
    public void ButtonI2()
    {
        textA.text += "る";
        name = textA.text;
    }
    public void ButtonI3()
    {
        textA.text += "れ";
        name = textA.text;
    }
    public void ButtonI4()
    {
        textA.text += "ろ";
        name = textA.text;
    }
    public void ButtonJ()
    {
        textA.text += "わ";
        name = textA.text;
    }
    public void ButtonJ2()
    {
        textA.text += "を";
        name = textA.text;
    }
    public void ButtonJ4()
    {
        textA.text += "ん";
        name = textA.text;
    }


    public void Button_a1()
    {
        textA.text += "a";
        name = textA.text;
    }
    public void Button_a2()
    {
        textA.text += "b";
        name = textA.text;
    }
    public void Button_a3()
    {
        textA.text += "c";
        name = textA.text;
    }
    public void Button_a4()
    {
        textA.text += "d";
        name = textA.text;
    }
    public void Button_a5()
    {
        textA.text += "e";
        name = textA.text;
    }
    public void Button_b1()
    {
        textA.text += "f";
        name = textA.text;
    }
    public void Button_b2()
    {
        textA.text += "g";
        name = textA.text;
    }
    public void Button_b3()
    {
        textA.text += "h";
        name = textA.text;
    }
    public void Button_b4()
    {
        textA.text += "i";
        name = textA.text;
    }
    public void Button_b5()
    {
        textA.text += "j";
        name = textA.text;
    }
    public void Button_c1()
    {
        textA.text += "k";
        name = textA.text;
    }
    public void Button_c2()
    {
        textA.text += "l";
        name = textA.text;
    }
    public void Button_c3()
    {
        textA.text += "m";
        name = textA.text;
    }
    public void Button_c4()
    {
        textA.text += "n";
        name = textA.text;
    }
    public void Button_c5()
    {
        textA.text += "o";
        name = textA.text;
    }
    public void Button_d1()
    {
        textA.text += "p";
        name = textA.text;
    }
    public void Button_d2()
    {
        textA.text += "q";
        name = textA.text;
    }
    public void Button_d3()
    {
        textA.text += "r";
        name = textA.text;
    }
    public void Button_d4()
    {
        textA.text += "s";
        name = textA.text;
    }
    public void Button_d5()
    {
        textA.text += "t";
        name = textA.text;
    }
    public void Button_e1()
    {
        textA.text += "u";
        name = textA.text;
    }
    public void Button_e2()
    {
        textA.text += "v";
        name = textA.text;
    }
    public void Button_e3()
    {
        textA.text += "w";
        name = textA.text;
    }
    public void Button_e4()
    {
        textA.text += "x";
        name = textA.text;
    }
    public void Button_e5()
    {
        textA.text += "y";
        name = textA.text;
    }
    public void Button_e6()
    {
        textA.text += "z";
        name = textA.text;
    }

    public void Button_A1()
    {
        textA.text += "A";
        name = textA.text;
    }
    public void Button_A2()
    {
        textA.text += "B";
        name = textA.text;
    }
    public void Button_A3()
    {
        textA.text += "C";
        name = textA.text;
    }
    public void Button_A4()
    {
        textA.text += "D";
        name = textA.text;
    }
    public void Button_A5()
    {
        textA.text += "E";
        name = textA.text;
    }
    public void Button_B1()
    {
        textA.text += "F";
        name = textA.text;
    }
    public void Button_B2()
    {
        textA.text += "G";
        name = textA.text;
    }
    public void Button_B3()
    {
        textA.text += "H";
        name = textA.text;
    }
    public void Button_B4()
    {
        textA.text += "I";
        name = textA.text;
    }
    public void Button_B5()
    {
        textA.text += "J";
        name = textA.text;
    }
    public void Button_C1()
    {
        textA.text += "K";
        name = textA.text;
    }
    public void Button_C2()
    {
        textA.text += "L";
        name = textA.text;
    }
    public void Button_C3()
    {
        textA.text += "M";
        name = textA.text;
    }
    public void Button_C4()
    {
        textA.text += "N";
        name = textA.text;
    }
    public void Button_C5()
    {
        textA.text += "O";
        name = textA.text;
    }
    public void Button_D1()
    {
        textA.text += "P";
        name = textA.text;
    }
    public void Button_D2()
    {
        textA.text += "Q";
        name = textA.text;
    }
    public void Button_D3()
    {
        textA.text += "R";
        name = textA.text;
    }
    public void Button_D4()
    {
        textA.text += "S";
        name = textA.text;
    }
    public void Button_D5()
    {
        textA.text += "T";
        name = textA.text;
    }
    public void Button_E1()
    {
        textA.text += "U";
        name = textA.text;
    }
    public void Button_E2()
    {
        textA.text += "V";
        name = textA.text;
    }
    public void Button_E3()
    {
        textA.text += "W";
        name = textA.text;
    }
    public void Button_E4()
    {
        textA.text += "X";
        name = textA.text;
    }
    public void Button_E5()
    {
        textA.text += "Y";
        name = textA.text;
    }
    public void Button_E6()
    {
        textA.text += "Z";
        name = textA.text;
    }


    public void Enter()
    {
        if (name != "")
        {
            SceneManager.LoadScene("NameEnter");
        }
    }

    public void Alfa()
    {
        if (english.activeSelf)
        {
            smallenglish.SetActive(true);
            english.SetActive(false);
            japanese.SetActive(false);
            da.SetActive(false);
            pa.SetActive(false);
            smalltext.SetActive(false);
        }
        else if(smallenglish.activeSelf)
        {
            da.SetActive(true);
            pa.SetActive(true);
            smalltext.SetActive(true);
            english.SetActive(false);
            japanese.SetActive(true);
            smallenglish.SetActive(false); 

        }
        else
        {
            da.SetActive(false);
            pa.SetActive(false);
            smalltext.SetActive(false);
            english.SetActive(true);
            japanese.SetActive(false);
            smallenglish.SetActive(false);
        }

    }

    public void Destory()
    {
        if (name != "")
        {
            name = name.Substring(0, name.Length - 1);
            textA.text = name;
        }
    }

    public void Pa()
    {
        string last = name.Substring(name.Length - 1);
        if (last == "は")
        {
            Destory();
            name += "ぱ";
        }
        if (last == "ひ")
        {
            Destory();
            name += "ぴ";
        }
        if (last == "ふ")
        {
            Destory();
            name += "ぷ";
        }
        if (last == "へ")
        {
            Destory();
            name += "ぺ";
        }
        if (last == "ほ")
        {
            Destory();
            name += "ぽ";
        }
        if (last == "ぱ")
        {
            Destory();
            name += "は";
        }
        if (last == "ぴ")
        {
            Destory();
            name += "ひ";
        }
        if (last == "ぷ")
        {
            Destory();
            name += "ふ";
        }
        if (last == "ぺ")
        {
            Destory();
            name += "へ";
        }
        if (last == "ぽ")
        {
            Destory();
            name += "ほ";
        }
        textA.text = name;
    }

    public void Da()
    {
        string last = name.Substring(name.Length - 1);
        if (last == "か")
        {
            Destory();
            name += "が";
        }
        if (last == "き")
        {
            Destory();
            name += "ぎ";
        }
        if (last == "く")
        {
            Destory();
            name += "ぐ";
        }
        if (last == "け")
        {
            Destory();
            name += "げ";
        }
        if (last == "こ")
        {
            Destory();
            name += "ご";
        }
        if (last == "さ")
        {
            Destory();
            name += "ざ";
        }
        if (last == "し")
        {
            Destory();
            name += "じ";
        }
        if (last == "す")
        {
            Destory();
            name += "ず";
        }
        if (last == "せ")
        {
            Destory();
            name += "ぜ";
        }
        if (last == "そ")
        {
            Destory();
            name += "ぞ";
        }
        if (last == "た")
        {
            Destory();
            name += "だ";
        }
        if (last == "ち")
        {
            Destory();
            name += "ぢ";
        }
        if (last == "つ")
        {
            Destory();
            name += "づ";
        }
        if (last == "て")
        {
            Destory();
            name += "で";
        }
        if (last == "と")
        {
            Destory();
            name += "ど";
        }
        if (last == "は")
        {
            Destory();
            name += "ば";
        }
        if (last == "ひ")
        {
            Destory();
            name += "び";
        }
        if (last == "ふ")
        {
            Destory();
            name += "ぶ";
        }
        if (last == "へ")
        {
            Destory();
            name += "べ";
        }
        if (last == "ほ")
        {
            Destory();
            name += "ぼ";
        }
        if (last == "が")
        {
            Destory();
            name += "か";
        }
        if (last == "ぎ")
        {
            Destory();
            name += "き";
        }
        if (last == "ぐ")
        {
            Destory();
            name += "く";
        }
        if (last == "げ")
        {
            Destory();
            name += "け";
        }
        if (last == "ご")
        {
            Destory();
            name += "こ";
        }
        if (last == "ざ")
        {
            Destory();
            name += "さ";
        }
        if (last == "じ")
        {
            Destory();
            name += "し";
        }
        if (last == "ず")
        {
            Destory();
            name += "す";
        }
        if (last == "ぜ")
        {
            Destory();
            name += "せ";
        }
        if (last == "ぞ")
        {
            Destory();
            name += "そ";
        }
        if (last == "だ")
        {
            Destory();
            name += "た";
        }
        if (last == "ぢ")
        {
            Destory();
            name += "ち";
        }
        if (last == "づ")
        {
            Destory();
            name += "つ";
        }
        if (last == "で")
        {
            Destory();
            name += "て";
        }
        if (last == "ど")
        {
            Destory();
            name += "と";
        }
        if (last == "ば")
        {
            Destory();
            name += "は";
        }
        if (last == "び")
        {
            Destory();
            name += "ひ";
        }
        if (last == "ぶ")
        {
            Destory();
            name += "ふ";
        }
        if (last == "べ")
        {
            Destory();
            name += "へ";
        }
        if (last == "ぼ")
        {
            Destory();
            name += "ほ";
        }
        textA.text = name;
    }

    public void Smalltext()
    {
        string last = name.Substring(name.Length - 1);
        if (last == "あ")
        {
            Destory();
            name += "ぁ";
        }
        if (last == "い")
        {
            Destory();
            name += "ぃ";
        }
        if (last == "う")
        {
            Destory();
            name += "ぅ";
        }
        if (last == "え")
        {
            Destory();
            name += "ぇ";
        }
        if (last == "お")
        {
            Destory();
            name += "ぉ";
        }
        if (last == "や")
        {
            Destory();
            name += "ゃ";
        }
        if (last == "ゆ")
        {
            Destory();
            name += "ゅ";
        }
        if (last == "よ")
        {
            Destory();
            name += "ょ";
        }
        if (last == "ぁ")
        {
            Destory();
            name += "あ";
        }
        if (last == "ぃ")
        {
            Destory();
            name += "い";
        }
        if (last == "ぅ")
        {
            Destory();
            name += "う";
        }
        if (last == "ぇ")
        {
            Destory();
            name += "え";
        }
        if (last == "ぉ")
        {
            Destory();
            name += "お";
        }
        if (last == "ゃ")
        {
            Destory();
            name += "や";
        }
        if (last == "ゅ")
        {
            Destory();
            name += "ゆ";
        }
        if (last == "ょ")
        {
            Destory();
            name += "よ";
        }
        if (last == "つ")
        {
            Destory();
            name += "っ";
        }
        if (last == "っ")
        {
            Destory();
            name += "つ";
        }
        textA.text = name;
    }

    public static string GetName()
    {
        return name;
    }
}
