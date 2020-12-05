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
        //오브젝트 물체
        talkData.Add(100, new string[] { "이상하게 생긴 사슴이다.", "별 상관 없는 물건인 것 같다."});

        //npc 천번대부터 시작
        talkData.Add(1000, new string[] {"이게 무슨 일이지?", "나도 모르겠어... 그저 자리를 지키고 있을 뿐"});
        talkData.Add(1010, new string[] { "호기심은 언제나 위험하지", "호기심을 가지는 건 죄일까 아닐까"});
        talkData.Add(1020, new string[] {"너무 으스스하지 않아?","난 항상 추워..."});
        talkData.Add(1030, new string[] {"치마를 입기에는 너무 추워보이는데", "난 아직도 뜨거워.그래서 뜨거운게 필요해"});
        talkData.Add(1040, new string[] {"우린 무슨 죄를 짓고 여길 온걸까","그건 너도 모르고 나도 모르지만 하나 확실한 건 너랑 나는 똑같다는 것뿐"});
        talkData.Add(1050, new string[] {"수염을 멋지게도 기르시네요","더이상 안깍아도 되는 장점도 있다네" });
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
