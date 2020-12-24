using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 대사를 한번에 띄우지않고 한글자씩 입력되는 방식으로 띄우는 코드

public class TalkAnimation : MonoBehaviour
{
    public int CPS;
    public GameObject Cursor;
    string Target;
    Text msgText;
    int index;
    float intervel;
    public bool isTyping;
    void Awake()
    {
        msgText = GetComponent<Text>();
    }

    public void SetMsg(string msg)
    {
        if(isTyping)
        {
            msgText.text = Target;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            Target = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        Cursor.SetActive(false);

        intervel = 1.0f / CPS;
        isTyping = true;
        Invoke("Effecting",intervel);
    }

    void Effecting()
    {
        if(msgText.text == Target)
        {
            EffectEnd();
            return;
        }
        msgText.text += Target[index];
        index++;
        Invoke("Effecting", intervel);
    }

    void EffectEnd()
    {
        isTyping = false;
        Cursor.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
