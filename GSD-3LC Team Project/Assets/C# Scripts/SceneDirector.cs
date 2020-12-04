﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneDirector : MonoBehaviour
{
    GameObject Scene1, Scene2, Scene3, Scene4;
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
        Scene1 = GameObject.Find("CutScene1");
        Scene2 = GameObject.Find("CutScene2");
        Scene3 = GameObject.Find("CutScene3");
        Scene4 = GameObject.Find("CutScene4");
        text1 = GameObject.Find("Text").GetComponent<Text>();
        //talkpanel.SetActive(true);
        ChangeScene = 1;
        Scene2.SetActive(false);
        Scene3.SetActive(false);
        Scene4.SetActive(false);
        Scene1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && SceneNo <= 5)
        {
            
            Debug.Log(SceneNo);
            ChangeScene = 1;
            if (SceneNo == 4)
            {
                SceneManager.LoadScene("Tutorial Scene");
            }
            SceneNo++;
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
                        text1.text = "하.. 코딩";
                        break;
                    case 2:
                        Scene2.SetActive(true);
                        Scene1.SetActive(false);
                        Scene3.SetActive(false);
                        text1.text = "이 게임은 코딩을 어떻게 했길레 버그가 이렇게 많아..?";
                        break;
                    case 3:
                        Scene3.SetActive(true);
                        Scene2.SetActive(false);
                        Scene4.SetActive(false);
                        text1.text = "후.. 머리도 아픈데 잠이나 자자..";
                        break;
                    case 4:
                        Scene3.SetActive(false);
                        Scene4.SetActive(true);
                        text1.text = "으음...응?";
                        break;
                    case 5:
                        break;
                }
                ChangeScene = 0;
            }
        }
    }
}
