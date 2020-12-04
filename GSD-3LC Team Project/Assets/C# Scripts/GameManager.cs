using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkpanel;
    public Text talktxt;
    public GameObject scanObject;
    public bool istalking;

    // Start is called before the first frame update

    public void Action(GameObject scanObj)
    {
        if(istalking) //대화중이면 대화 끄기
        {
            istalking = false;
        }
        else //대화시작
        {
            istalking = true;
            scanObject = scanObj;
            talktxt.text = "이것은 " + scanObject.name + "이다."; // 스페이스 누르면 대화창에 물체 이름 출력
        }
        talkpanel.SetActive(istalking);
    }
    void Start()
    {
        talkpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
