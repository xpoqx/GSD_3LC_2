using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManger : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    Dictionary<int, Sprite> InteractData;


    public Sprite[] portraitArr;
    public Sprite[] InteractArr;
    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        InteractData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData() //숫자로 물체 구분, 대화 문장 입력
    {
        //오브젝트 물체
        talkData.Add(2, new string[] { "앞에서 살펴봐야 할 것 같다." });
        talkData.Add(3, new string[] { "서랍을 밀었다." });
        talkData.Add(4, new string[] { "서랍을 밀었더니 문이 나타났다." });
        talkData.Add(5, new string[] { "작은 열쇠를 찾았다." });
        InteractData.Add(5, InteractArr[0]);

        talkData.Add(997, new string[] { "이 문은 이미 열려있다." });
        talkData.Add(998, new string[] { "문이 열렸다!" });
        talkData.Add(999, new string[] { "이 문은 잠겨있는 것 같다." });
        talkData.Add(444, new string[] { "악마의 형상이다." });
       // talkData.Add(445, new string[] { "악마의 형상이다." });
        talkData.Add(9999, new string[] { "이 문은 잠겨있는 것 같다.", "이상하게 더 열고 싶은 문이다." });

        talkData.Add(11, new string[] { "이 신발 비싼건데?:0", "신발의 뱀이 물고있던 사과를 떼어냈다.:0" });//그냥 마네킹
        talkData.Add(12, new string[] { "맛있어 보이는 사과지만..:0", "독이 들어있을지 모르니 네가 대신 먹어라:0" });//구찌스네이크의 사과
        talkData.Add(13, new string[] { "마네킹이 사과를 물고 있다.:0" });//사과 문 마네킹
        //talkData.Add(100, new string[] { "이상하게 생긴 사슴이다.", "별 상관 없는 물건인 것 같다." }); //테스트용 사슴
        InteractData.Add(11, InteractArr[1]);
        InteractData.Add(12, InteractArr[2]);
        InteractData.Add(13, InteractArr[3]);

        talkData.Add(123, new string[] { "알파벳 'a' 가 적혀 있다" });
        talkData.Add(456, new string[] { "알파벳 'p' 가 적혀 있다" });
        talkData.Add(777, new string[] { "지옥 by 단테..? 그럼 신곡 안에 있는 내용인가..?" });

        talkData.Add(101, new string[] { "벼? 가을인가 보네. 근데 뭔가 허전하다.:0" });//벼 그림
        InteractData.Add(101, InteractArr[4]);
        talkData.Add(102, new string[] { "따뜻해 보이는 태양 문양이다." });//태양 문양 획득
        talkData.Add(103, new string[] { "문양을 그림 위에 올려놓았다.:0", "...어차피 대중은 개돼지야...:0" });//태양 문양을 벼에다가 놓음
        InteractData.Add(103, InteractArr[10]);
        talkData.Add(104, new string[] { "...어차피 대중은 개돼지야...:0" });//벼 다시 누를때
        InteractData.Add(104, InteractArr[11]);

        talkData.Add(201, new string[] { "시계 밑에 작은 글씨로 5시 40분이 적혀 있다.:0" });//시계
        InteractData.Add(201, InteractArr[5]);
        talkData.Add(202, new string[] { "이렇게 해도 5시 40분이라고 할 수 있을까." });//시계2

        //talkData.Add(301, new string[] { "" });//시크릿 열쇠
        talkData.Add(304, new string[] { "뭐야, 주울 수 있었잖아?:0" });//시크릿 열쇠
        InteractData.Add(304, InteractArr[6]);

        talkData.Add(401, new string[] { "어울리지 않게 리어카와 귀여운 곰인형이 함께 있다:0" }); // 곰인형
        InteractData.Add(401, InteractArr[7]);
        talkData.Add(402, new string[] { "곰인형이 넘어졌다.:0" });
        InteractData.Add(402, InteractArr[7]);
        talkData.Add(405, new string[] { "벽에 동그란 뭔가가 박혀있다.","오래된 열쇠인 것 같다." });

        talkData.Add(501, new string[] { "무거워 보인다.:0" }); // 아틀라스 석상
        InteractData.Add(501, InteractArr[8]);
        talkData.Add(502, new string[] { "돌을 떨어뜨리게 했다.:0" }); // 아틀라스 석상 item1 아이템 보유시 변경대사 테스트
        InteractData.Add(502, InteractArr[8]);

        talkData.Add(601, new string[] { "보통 이 반대로 돼 있지 않나?:0" }); //체스판
        InteractData.Add(601, InteractArr[12]);
        talkData.Add(602, new string[] { "역시 킹이 제일 뒤로 와야지.:0" }); //체스판 미션 후 
        InteractData.Add(602, InteractArr[12]);

        //talkData.Add(402, new string[] { "작은 수레에 걸쇠가 걸려있다." });//수레

        //talkData.Add(270, new string[] { "이렇게 해도 5시 40분인건가.." });//시계 2
        //talkData.Add(280, new string[] { "바위다." });//바위

        talkData.Add(510, new string[] { "이번엔 학생들..인가?:0" });
        InteractData.Add(510, InteractArr[9]);
        talkData.Add(520, new string[] { "어딘가 수상해보이는 사람들이다.:0" });
        InteractData.Add(520, InteractArr[15]);
        talkData.Add(530, new string[] { "어디서 생겨난지 모를 사진이 있다.:0","사람들이 시위를 하고 모습이 담겨있다.:0" });
        InteractData.Add(530, InteractArr[13]);
        talkData.Add(540, new string[] { "진짜 사람을 죽인건가?..:0" });
        InteractData.Add(540, InteractArr[16]);
        talkData.Add(550, new string[] { "깜짝이야.. 교통사고가 난 모습이다:0" });
        InteractData.Add(550, InteractArr[14]);


        talkData.Add(310, new string[] { "마네킹:0" });
        
        //npc 천번대부터 시작
        talkData.Add(1000, new string[] { "이게 무슨 일이지?:0", "나도 모르겠어... 그저 자리를 지키고 있을 뿐:0" }); //  인색
        talkData.Add(1010, new string[] { "호기심은 언제나 위험하지..:0", "호기심을 가지는 건 죄일까 아닐까:0" }); // 탐욕
        talkData.Add(1020, new string[] { "너무 으스스하지 않아?:0", "난 항상 추워...:0" }); // 시기
        talkData.Add(1030, new string[] { "치마를 입기에는 너무 추워 보이는데.:0", "난 아직도 뜨거워. 그래서 뜨거운게 필요해:0" }); // 음욕
        talkData.Add(1040, new string[] { "우린 무슨 죄를 짓고 여기에 온 걸까..?:0", "그건 아무도 모르지만 확실한 건\n너랑 나는 똑같다는 것.:0" }); //분노
        talkData.Add(1050, new string[] { "수염을 멋지게도 기르시네요.:0", "더 이상 깎지 않아도 된다는 장점도 있다네.:0" }); // 태만
        //talkData.Add(1060, new string[] { "" }); 교만

        //초상화
        portraitData.Add(1000, portraitArr[0]);
        portraitData.Add(1010, portraitArr[1]);
        portraitData.Add(1020, portraitArr[2]);
        portraitData.Add(1030, portraitArr[3]);
        portraitData.Add(1040, portraitArr[4]);
        portraitData.Add(1050, portraitArr[5]);
        //portraitData.Add(1060, new string[] { "" }); 교만
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
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
    public Sprite GetInteract(int id, int InteractIndex)
    {
        return InteractData[id + InteractIndex];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
