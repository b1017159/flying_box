//2019/07/05
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
        //public float m_speed; // 移動する速さ
        private Vector3 m_direction;
        // Start is called before the first frame update
        private Vector3 player_position;
        private Vector3 camera_position;
        private float randm;
        public float speed;
        private float rotationSmooth = 100f;
        public float scale;//最大スケール
        private Vector3 targetPosition;  //行先
        private float changeTargetSqrDistance = 10f;//この距離以下になったら新しい場所を探す
        private float color_speed=0.01f;
        private float color=0;//初期透明度（透明）
        private float rotation;
        void Start()
        {
                targetPosition = GetRandomPositionOnLevel();
                gameObject.GetComponent<Renderer>().material.color=new Color(1,1,1,color);
                //this.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.25f);
                //transform.Rotate(new Vector3(0,0,90));
        }

        // Update is called once per frame
        void Update()
        {
                if(color<1) color=color+color_speed;
                gameObject.GetComponent<Renderer>().material.color=new Color(1,1,1,color);
                //最初は透明だが時間経過で色がつく
                float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
                //自信と目標の距離の差
                if (sqrDistanceToTarget < changeTargetSqrDistance)
                {
                        targetPosition = GetRandomPositionOnLevel();//小さければ選びなおし
                        //Debug.Log(targetPosition);
                }
                // 目標地点の方向を向く
                Vector3 relativePos=targetPosition - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(relativePos);

                //Vector3 tempSpear = this.transform.rotation;
                //tempSpear.z = 90;
                //this.transform.rotation = tempSpear;

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
                // 前方に進む
                //this.transform.rotation.eulerAngles.z=90;
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                float z = 90;
                float opposite =0;
                //this.transform.rotation = Quaternion.Euler(x, 5f, z);
                this.transform.Rotate( opposite, 0.0f, z);
                Debug.Log(relativePos+":"+relativePos.z+":"+this.transform.rotation);
        }
        void OnTriggerEnter(Collider other){
                if(other.gameObject.CompareTag("Enemy")) {
                        if(this.scale<other.gameObject.GetComponent<Enemy>().scale) {
                                Debug.Log(this.scale+":"+other.gameObject.GetComponent<Enemy>().scale);
                                //ジェネリクス
                                //Enemy型のコンポーネントを取得
                                //その収集アイテムを非表示にします
                                other.gameObject.SetActive(false);
                        }
                }
        }
        void OnCollisionEnter(Collision collision) {
                //衝突判定
                if (collision.gameObject.tag == "Player") {
                        //相手のタグがPlayerならば、自分を消す
                        //Destroy(this.gameObject);
                        this.gameObject.SetActive (false);
                }
        }

        void OnTriggerExit(Collider other){
                if(other.gameObject.CompareTag("Wall")) {
                        this.gameObject.SetActive(false);
                        //Debug.Log("wall");
                }
        }
        public void Init(){
                randm=Random.Range(1.0f,scale);
                //Debug.Log(randm);
                scale=randm;
                //string name=gameObject.name;
                //if(name==Rectangular_Enemy) {}
                //名前によってスケールを変えたい
                this.transform.localScale = new Vector3(2*scale, scale, scale);
                player_position=Player.m_instance.transform.position;                                      //自機のポジション
                //Debug.Log(player_position);
                camera_position=CameraController.m_instance.transform.position;
                //メインカメラのポジション
                //Debug.Log(camera_position);
                var pos = player_position-camera_position+player_position;
                //Debug.Log(pos);
                //ベクトル＋それなりの距離
                randm=Random.Range(0,2);
                if(randm==0) randm=Random.Range(-10.0f,-5.0f);
                if(randm==1) randm=Random.Range(5.0f,10.0f);
                pos.x= pos.x+randm;
                randm=Random.Range(1.0f,3.0f);
                pos.y= pos.y+randm;
                randm=Random.Range(0,2);
                if(randm==0) randm=Random.Range(-7.0f,-5.0f);
                if(randm==1) randm=Random.Range(5.0f,7.0f);
                //randm=Random.Range(-5.0f,5.0f);
                pos.z= pos.z+randm;
                transform.localPosition = pos;
        }
        public Vector3 GetRandomPositionOnLevel()
        {//ランダムに場所を取る関数
                float levelSize = 150f;
                return new Vector3(Random.Range(-levelSize, levelSize), 1, Random.Range(-levelSize, levelSize));
        }
}
