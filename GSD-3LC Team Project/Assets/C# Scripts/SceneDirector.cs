using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneDirector : MonoBehaviour
{
    GameObject Scene1, Scene2, Scene3, Scene4,Scene5;
    public Text text1;
    public static int SceneNo;
    public int ChangeScene;

    public GameObject talkpanel;
    public GameObject scanObject;
    public bool istalking;
    public TalkAnimation talk;
    public string naration;

    public void Narate(string naration)
    {
        string nstring = "";
        if (talk.isTyping)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            nstring = naration;
        }
        if (nstring == null)
        {
            istalking = false;
            return;
        }
        talk.SetMsg(nstring);
        istalking = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneNo = 1;
        Scene1 = GameObject.Find("CutScene1");
        Scene2 = GameObject.Find("CutScene2");
        Scene3 = GameObject.Find("CutScene3");
        Scene4 = GameObject.Find("CutScene4");
        Scene5 = GameObject.Find("CutScene5");
        text1 = GameObject.Find("Text").GetComponent<Text>();
        //talkpanel.SetActive(true);
        ChangeScene = 1;
        Scene2.SetActive(false);
        Scene3.SetActive(false);
        Scene4.SetActive(false);
        Scene5.SetActive(false);
        Scene1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && SceneNo <= 6 && !talk.isTyping) // 컷씬에서는 대사가 모두 출력되기 전에 다음 씬으로 넘어가지 않게 함
        {
            
            Debug.Log(SceneNo);
            ChangeScene = 1;
            if (SceneNo == 5)
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
            naration = "";
            {
                switch (SceneNo)
                {
                    case 1:
                        Scene1.SetActive(true);
                        Scene2.SetActive(false);
                        //text1.text = "...";
                        naration = "...";
                        Narate(naration);
                        break;
                    case 2:
                        Scene2.SetActive(true);
                        Scene1.SetActive(false);
                        Scene3.SetActive(false);
                        //text1.text = "세상 참 잘~ 돌아간다 ㅋㅋ";
                        naration = "세상 참 잘~ 돌아간다 ㅋㅋ";
                        Narate(naration);
                        break;
                    case 3:
                        Scene3.SetActive(true);
                        Scene2.SetActive(false);
                        Scene4.SetActive(false);
                        //text1.text = "머리도 아픈데 그만 잠이나 자자..";
                        naration = "머리도 아픈데 그만 잠이나 자자..";
                        Narate(naration);
                        break;
                    case 4:
                        Scene3.SetActive(false);
                        Scene4.SetActive(true);
                        Scene5.SetActive(false);
                        //text1.text = "드르렁...";
                        naration = "드르렁...";
                        Narate(naration);
                        break;
                    case 5:
                        Scene4.SetActive(false);
                        Scene5.SetActive(true);
                        //text1.text = "으음... ...응?";
                        naration = "으음... ...응?";
                        Narate(naration);
                        break;
                }
                ChangeScene = 0;
            }
        }
    }
}