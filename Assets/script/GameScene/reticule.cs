using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticule : MonoBehaviour
{

    public GameObject reticule_with_camera;


    private Vector3 replayer_position;
    private Vector3 replayer_forward;
    private Vector3 replayer_rotate;
    // Start is called before the first frame update
    public int distance = 4;
    private float color = 0.0f;//初期透明度（透明）
    public Transform first_person_camera;

    void Start()
    {

        if (this.name == "reticuleFPS")
        {
            //Debug.Log(this.name);
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, color);
           first_person_camera = Player.m_instance.transform.Find("First_person");
        }
        if (this.name == "reticuleTPS")
        {
            //Debug.Log(this.name);
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, color);
        }
        //Color color=gameObject.GetComponent<Renderer>().material.color;
        //color.a=0.0f;
        //gameObject.GetComponent<Renderer>().material.color=color;
    }

    // Update is called once per frame
    void Update()
    {



        if (this.name == "reticuleFPS")
        {
            replayer_position = first_person_camera.position;//自機のポジション
            replayer_forward = first_person_camera.forward;//自機のベクトル
            replayer_rotate = first_person_camera.localEulerAngles;//自機の傾き

            //Debug.Log("kawauchi");

        }

        if (this.name == "reticuleTPS")
        {
            replayer_position = Player.m_instance.transform.position;//自機のポジション
            replayer_forward  = Player.m_instance.transform.forward;//自機ののベクトル
            replayer_rotate   = Player.m_instance.transform.localEulerAngles;//自機の傾き

            //Debug.Log("Riku");

        }
        var retipos = replayer_position + replayer_forward * distance;
        //Debug.Log();
        //transform.localPosition =new Vector3(0f, 0f, 0f);

        transform.position = retipos;//自身の位置かえる
        transform.localEulerAngles = replayer_rotate;
        //Debug.Log(replayer_rotate);
    }
}
