using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HPbar : MonoBehaviour
{
        //HPオブジェクト
        public GameObject heart;
        public GameObject heart1;
        public GameObject heart2;
        public GameObject heart3;
        public GameObject heart4;
        private int count;
        // Start is called before the first frame update
        void Start()
        {
                count = Player.count;

                if (count == 1)
                {
                        heart4.SetActive(false);

                }
                if (count == 2)
                {
                        heart4.SetActive(false);
                        heart3.SetActive(false);

                }
                if (count == 3)
                {
                        heart4.SetActive(false);
                        heart3.SetActive(false);
                        heart2.SetActive(false);

                }
                if (count == 4)
                {
                        heart4.SetActive(false);
                        heart3.SetActive(false);
                        heart2.SetActive(false);
                        heart1.SetActive(false);

                }
        }

        // Update is called once per frame
        void Update()
        {
                count = Player.count;
                //Debug.Log(count);
                if (count == 1)
                {
                        heart4.SetActive(false);
                }
                if (count == 2)
                {
                        heart4.SetActive(false);
                        heart3.SetActive(false);
                }
                if (count == 3)
                {
                        heart4.SetActive(false);
                        heart3.SetActive(false);
                        heart2.SetActive(false);
                }
                if (count == 4)
                {
                        heart4.SetActive(false);
                        heart3.SetActive(false);
                        heart2.SetActive(false);
                        heart1.SetActive(false);
                }
                if (count == 5)
                {
                        heart4.SetActive(false);
                        heart3.SetActive(false);
                        heart2.SetActive(false);
                        heart1.SetActive(false);
                        heart.SetActive(false);
                }
                Scene loadscene = SceneManager.GetActiveScene();
                if (count == 5)
                {
                        if (loadscene.name == "GameStage1")
                        {
                                SceneManager.LoadScene("Stage1 G");
                                Player.count = 0;
                        }
                        if (loadscene.name == "GameStage2")
                        {
                                SceneManager.LoadScene("Stage2 G");
                                Player.count = 0;
                        }
                        if (loadscene.name == "GameStage3")
                        {
                                SceneManager.LoadScene("Stage3 G");
                                Player.count = 0;
                        }

                }
        }
}
