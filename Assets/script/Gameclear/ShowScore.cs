using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShowScore : MonoBehaviour
{
    private TextMesh Result;

    double score;

    string username;

    public static double Scale_hikitugi;

    // Start is called before the first frame update
    void Start()
    {
        Result = GetComponentInChildren<TextMesh>();

        score = ScoreText.GetScore();

        username = InputFieldManager.GetName();
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        Result.text = username+"のスコア　"+score+"cm";

        Scene loadscene = SceneManager.GetActiveScene();
        if (loadscene.name == "Stage1 G")
        {
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                SceneManager.LoadScene("GameStage1");
                //Scale_hikitugi = Player.scoredata;
        
            }
        }
        if (loadscene.name == "Stage2 G")
        {
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                SceneManager.LoadScene("GameStage2");
                //Scale_hikitugi = Player.scoredata;
            }
        }
        if (loadscene.name == "Stage3 G")
        {
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                SceneManager.LoadScene("GameStage3");
                //Scale_hikitugi = Player.scoredata;
            }
        }
        if (loadscene.name == "ClearScene")
        {
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                SceneManager.LoadScene("GameStage1");
                      Player.scoredata = 30;
                Player.sizedata = 3f;

            }
        }
        if (OVRInput.Get(OVRInput.RawButton.B))
        {
            SceneManager.LoadScene("GameTitle");
            Player.scoredata = 30;
            Player.sizedata = 3f;
        }


    }

}
