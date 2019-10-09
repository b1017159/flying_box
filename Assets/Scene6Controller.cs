using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ボタンを使用するためUIとSceneManagerを使用ためSceneManagementを追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene6Controller : MonoBehaviour
{


    // ボタンをクリックするとBattleSceneに移動します
    public void ButtonClicked()
    {

        SceneManager.LoadScene("LightMenu");
    
        //DeleteTargetObj という名前のオブジェクトを取

        GameObject obj = GameObject.Find("SunLight");

        // 指定したオブジェクトを削除

        Destroy(obj);
    }

}