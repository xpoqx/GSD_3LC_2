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
        talkData.Add(100, new string[] { "이상하게 생긴 사슴이다.", "별 상관 없는 물건인 것 같다." }); //테스트용 사슴
        talkData.Add(200, new string[] { "무거워 보인다." }); // 아틀라스 석상
        talkData.Add(201, new string[] { "무거워 보인다 돌은 어디로 갔지?" }); // 아틀라스 석상 item1 아이템 보유시 변경대사 테스트
        talkData.Add(210, new string[] { "어울리지 않게 귀여운 곰인형이 있다" }); // 곰인형
        talkData.Add(220, new string[] { "보통 이 반대로 돼 있지 않나?" }); //체스판
        talkData.Add(230, new string[] { "이 신발 비싼건데?" });//쿠찌스네이크
        talkData.Add(240, new string[] { "벼? 가을인가 보네. 근데 너무 어둡군." });//벼 그림
        talkData.Add(250, new string[] { "작은 수레에 걸쇠가 걸려있다." });//수레
        talkData.Add(260, new string[] { "작은 글씨로 5시 40분이 적혀 있다." });//시계
        talkData.Add(270, new string[] { "이렇게 해도 5시 40분인건가.." });//시계 2
        talkData.Add(280, new string[] { "바위다" });//바위

        //npc 천번대부터 시작
        talkData.Add(1000, new string[] { "이게 무슨 일이지?", "나도 모르겠어... 그저 자리를 지키고 있을 뿐" });
        talkData.Add(1010, new string[] { "호기심은 언제나 위험하지", "호기심을 가지는 건 죄일까 아닐까" });
        talkData.Add(1020, new string[] { "너무 으스스하지 않아?", "난 항상 추워..." });
        talkData.Add(1030, new string[] { "치마를 입기에는 너무 추워보이는데", "난 아직도 뜨거워.그래서 뜨거운게 필요해" });
        talkData.Add(1040, new string[] { "우린 무슨 죄를 짓고 여길 온걸까", "그건 너도 모르고 나도 모르지만 하나 확실한 건 너랑 나는 똑같다는 것뿐" });
        talkData.Add(1050, new string[] { "수염을 멋지게도 기르시네요", "더이상 안깍아도 되는 장점도 있다네" });
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
