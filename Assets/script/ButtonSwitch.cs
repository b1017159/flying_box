using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ButtonSwitch : MonoBehaviour{

    [MenuItem("UITools/ボタンの色を変更", false, 1)]

    static void ChangeButtonColor(MenuCommand command)
    {
        GameObject obj = Selection.activeGameObject;

        var button = obj.GetComponent<Button>();
        var colors = button.colors;

        colors.normalColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.highlightedColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.pressedColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);
        colors.disabledColor = new Color(165f / 255f, 220f / 255f, 192f / 255f, 255f / 255f);

        button.colors = colors;

        Debug.Log(colors + " ボタンの色を変更しました。", button.gameObject);
    }
}

