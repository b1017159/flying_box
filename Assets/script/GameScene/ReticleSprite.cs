using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleSprite : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    private int reticleSignal; //レティクルを切り替えるための信号
    public Sprite Reticle; //動作中のレティクル
    public Sprite NotReticle; //非動作中のレティクル
                              //  Start is called before the first frame update
    void Start()
    {
        reticleSignal = Enemy.reticleSignal;
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        MainSpriteRenderer.sprite = NotReticle;

    }

    // Update is called once per frame
    void Update()
    {
        reticleSignal = Enemy.reticleSignal;
//        Debug.Log(reticleSignal);
        if (reticleSignal == 1) //レティクル内に魚がいる時にレティクルを切り替え
        {
            MainSpriteRenderer.sprite = Reticle;
        }
        else
        {
            MainSpriteRenderer.sprite = NotReticle;
        }

    }
}
