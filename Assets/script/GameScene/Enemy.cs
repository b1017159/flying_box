//2019/07/05
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
        //public float m_speed; // 移動する速さ//test
        private Vector3 m_direction;
        // Start is called before the first frame update
        private Vector3 player_position;
        private Vector3 camera_position;
        private Vector3 pole_position;
        private float randm;
        public float speed=1f;
        private float rotationSmooth = 100f;
        public float scale=10f;//最大スケール
        public float min_scale=1f;//最小スケール
        private float scale_multiple=0.3f;//スケールは0.1倍になる
        public string name;
        private Vector3 targetPosition;  //行先
        private float changeTargetSqrDistance = 10f;//この距離以下になったら新しい場所を探す
        private float color_speed=0.01f;
        private float color=0;//初期透明度（透明）
        private float rotation;
        public static int reticleSignal = 0;//FPSorTPSを判断
        public bool Chase=false;//追いかけるかどうかの設定
        private bool evasion=false;//startで発動しない
        //GameObject target_old = this.gameObject;
        // Transform target = target_old.transform.Find("enemy_info"); //子オブジェクトの3Dテキストを見つける
        Enemy_info target;//enemyinfoのスクリプトを取得
        public GameObject targetObject;//ennemy_info
        public GameObject S_color;
        private float distance;

        void Start()
        {
                if(Chase==true) {
                        changeTargetSqrDistance = 0; //こうしないと追いかける魚が回転し始める
                        print("Chase_Start");
                }
                targetPosition = GetRandomPositionOnLevel(this.transform.position.y);//ランダムに場所を取得
                // gameObject.GetComponent<Renderer>().material.color=new Color(1,1,1,color);//透明化
                //this.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.25f);
                //transform.Rotate(new Vector3(0,0,90));

                target = this.transform.Find("enemy_info").GetComponent<Enemy_info>();
                //発生するまで親子関係が無いので上で書かずstartで書く
                // Enemy_info target = targetObject.GetComponent<Enemy_info>();
                if(name==null) name = transform.name;
                if (target == null) print("enemy_infoなし");
                if(target!=null) target.Display(scale,scale_multiple,name);
        }

        // Update is called once per frame
        void Update()
        {
                if(Chase==true) {
                        targetPosition=Player.m_instance.transform.position;
                }
                //最初は透明だが時間経過で色がつく
                float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
                //自身と目標の距離の差
                if (sqrDistanceToTarget < changeTargetSqrDistance)
                {
                        targetPosition = GetRandomPositionOnLevel(this.transform.position.y);//小さければ選びなおし
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
                //float opposite =180;
                //float chokaku=90;
                //this.transform.rotation = Quaternion.Euler(x, 5f, z);
                //this.transform.Rotate( 0.0f, opposite, opposite);
                //Debug.Log(relativePos+":"+relativePos.z+":"+this.transform.rotation);
                //角度を調整してから表示
                if (S_color == null)
                { print(this.name + "写真なし"); }
                if (S_color != null)
                {
                        S_color.gameObject.SetActive(true); //salmon display
                }
        }
        void OnTriggerEnter(Collider other){
                if(other.gameObject.CompareTag("Enemy")) {
                        if (this.scale<other.gameObject.GetComponent<Enemy>().scale) {

                                //Debug.Log(this.scale+":"+other.gameObject.GetComponent<Enemy>().scale);
                                //ジェネリクス
                                //Enemy型のコンポーネントを取得
                                //その収集アイテムを非表示にします
                                other.gameObject.SetActive(false);
                                target.Display(scale,scale_multiple,name);
                                //print("Triggererror");
                        }
                }
        }
        //void OnCollisionEnter(Collision collision) {
        //衝突判定
        //      if (collision.gameObject.tag == "Player") {
        //相手のタグがPlayerならば、自分を消す
        //            Debug.Log("player");
        //Destroy(this.gameObject);
        //          this.gameObject.SetActive (false);
        //  }
        //  }

        void OnTriggerExit(Collider other){
                if(other.gameObject.CompareTag("Wall")) {
                        this.gameObject.SetActive(false);
                        //Debug.Log("wall");
                }
                if(other.gameObject.CompareTag("reticule")) {
                        target.Color_zero();
                }
        }
        void OnTriggerStay(Collider other){
                //Istriが付いているのでOnCollisionStayではない　引数も注意
                //レティクルに当たると情報表示
                if(other.gameObject.CompareTag("reticule")) {
                        reticleSignal = 1;
                        target.Aaper();
                        //Debug.Log("reticule");
                        //targetObject.Display(scale,name);
                }
                else
                {
                        reticleSignal = 0;
                }
        }
        public void Init(){
                randm=Random.Range(min_scale,scale);
                scale=randm*scale_multiple;
                //名前によってスケールを変えたい
                this.transform.localScale = new Vector3(scale, scale, scale);
                //if(Chase==true) this.transform.localScale=Player.m_instance.scale;//プレイヤーと同じ大きさ
                player_position=Player.m_instance.transform.position;//自機のポジション
                //Debug.Log(player_position);
                camera_position=CameraController.m_instance.transform.position;
                pole_position=Pole.m_instance.transform.position;
                //メインカメラのポジション
                //Debug.Log(camera_position);
                var pos = player_position - pole_position + player_position;
                //Debug.Log(pos);
                //ベクトル＋それなりの距離
                if(Chase==true) {
                        pos = pos*3;
                }else{
                        while (true)
                        {

                                randm = Random.Range(0, 2);
                                if (randm == 0) randm = Random.Range(-10.0f, -5.0f);
                                if (randm == 1) randm = Random.Range(5.0f, 10.0f);
                                pos.x = pos.x + randm;
                                randm = Random.Range(1.0f, 3.0f);
                                pos.y = pos.y + randm;
                                randm = Random.Range(0, 2);
                                if (randm == 0) randm = Random.Range(-7.0f, -5.0f);
                                if (randm == 1) randm = Random.Range(5.0f, 7.0f);
                                //randm=Random.Range(-5.0f,5.0f);
                                pos.z = pos.z + randm;
                                distance = Vector3.SqrMagnitude(pos- player_position);
                                if (distance >= 200) break;
                        }
                        Debug.Log("distance" + distance);
                }
                transform.localPosition = pos;
        }
        public Vector3 GetRandomPositionOnLevel(float y)
        {
                //Playerが下に行き過ぎるとEnemyが全員上を向いてしまうのでY座標は固定する
                //ランダムに場所を取る関数
                // if(Chase==true) {
                //         return Player.m_instance.transform.position;
                // }
                float levelSize = 150f;
                return new Vector3(Random.Range(-levelSize, levelSize), y, Random.Range(-levelSize, levelSize));
        }
}
