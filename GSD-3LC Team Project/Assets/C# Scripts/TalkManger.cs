using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManger : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData() //숫자로 물체 구분, 대화 문장 입력
    {
        talkData.Add(100, new string[] { "이상하게 생긴 사슴이다.", "별 상관 없는 물건인 것 같다." });
    }

    public string GetTalk(int id, int talkindex)
    {
        if(talkindex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkindex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
