using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneDirector : MonoBehaviour
{
    GameObject Scene1, Scene2;
    public Text text1;
    public static int SceneNo;
    public int ChangeScene;

    public GameObject talkpanel;
    public GameObject scanObject;
    public bool istalking;

    // Start is called before the first frame update
    void Start()
    {
        SceneNo = 1;
        Scene1 = GameObject.Find("Scene1");
        Scene2 = GameObject.Find("Scene2");
        text1 = GameObject.Find("Text").GetComponent<Text>();
        //talkpanel.SetActive(true);
        ChangeScene = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && SceneNo <= 3)
        {
            SceneNo++;
            Debug.Log(SceneNo);
            ChangeScene = 1;
            if (SceneNo == 4)
            {
                SceneManager.LoadScene("Tutorial Scene");
            }
        }
        else if (Input.GetMouseButtonDown(1) && SceneNo >= 2)
        {
            SceneNo--;
            Debug.Log(SceneNo);
            ChangeScene = 1;
        }
        if (ChangeScene == 1)
        {
            {
                switch (SceneNo)
                {
                    case 1:
                        Scene1.SetActive(true);
                        Scene2.SetActive(false);
                        text1.text = "오늘도 평범하게 힘든 하루였다..";
                        break;
                    case 2:
                        Scene2.SetActive(true);
                        Scene1.SetActive(false);
                        text1.text = "뭐야";
                        break;
                    case 3:
                        Destroy(Scene1);
                        Destroy(Scene2);
                        text1.text = "3번째 텍스트";
                        break;
                }
                ChangeScene = 0;
            }
        }
    }
}
