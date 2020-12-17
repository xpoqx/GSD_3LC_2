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


    public void GenerateData() //숫자로 물체 구분, 대화 문장 입력
    {
        //불러온  Sin번호에 따라 대사를 다르게 입력, 1=교만,2=분노,3=음욕.
        //0. 공통 대사

        //1. 교만 대사

        //2. 분노 대사

        //3. 음욕 대사

        talkData.Add(10000, new string[] { "철컥..", "뭔가가 열리는 소리가 났다." });
        talkData.Add(3, new string[] { "서랍 안에서 작은 열쇠를 찾았다.", "문을 열 수 있을까?" });
        talkData.Add(4, new string[] { "텅 빈 것 같다." });
        talkData.Add(5, new string[] { "벽이 미세하게 흔들리는 것 같다." });
        talkData.Add(6, new string[] { "어라..? 벽이 움직인다!" });
        InteractData.Add(5, InteractArr[0]);

        talkData.Add(997, new string[] { "이 문은 이미 열려있다." });
        talkData.Add(998, new string[] { "문이 열렸다!" });
        talkData.Add(999, new string[] { "이 문은 잠겨있는 것 같다." });
        talkData.Add(444, new string[] { "악마의 형상이다." });
        talkData.Add(9999, new string[] { "이 문은 잠겨있는 것 같다.", "이상하게 더 열고 싶은 문이다." });

        talkData.Add(10, new string[] { "이상하게 생긴 마네킹이다.:0" }); // 교만 아닌 경우 나올 대사
        talkData.Add(11, new string[] { "이 신발 비싼건데?:0", "신발의 뱀이 물고있던 사과를 떼어냈다.:0" });//그냥 마네킹
        talkData.Add(12, new string[] { "맛있어 보이는 사과지만..:0", "독이 들어있을지 모르니 네가 대신 먹어라:0" });//구찌스네이크의 사과
        talkData.Add(13, new string[] { "마네킹이 사과를 물고 있다.:0" });//사과 문 마네킹
        InteractData.Add(10, InteractArr[2]); // 교만 아닌 경우 나올 사진(그냥 마네킹)
        InteractData.Add(11, InteractArr[1]);
        InteractData.Add(12, InteractArr[2]);
        InteractData.Add(13, InteractArr[3]);


        talkData.Add(123, new string[] { "알파벳 'a' 가 적혀 있다" });
        talkData.Add(456, new string[] { "알파벳 'p' 가 적혀 있다" });
        talkData.Add(777, new string[] { "지옥 by 단테..? 그럼 신곡 안에 있는 내용인가..?" });


        talkData.Add(100, new string[] { "벼..? 마지막으로 밥을 먹은게 언제더라..:0" });//교만 아닌 벼 그림 상호작용
        talkData.Add(101, new string[] { "벼? 가을인가 보네. 근데 뭔가 허전하다.:0" });//벼 그림
        talkData.Add(102, new string[] { "따뜻해 보이는 태양 문양이다." });//태양 문양 획득
        talkData.Add(103, new string[] { "문양을 그림 위에 올려놓았다.:0", "...어차피 대중은 개돼지야...:0" });//태양 문양을 벼에다가 놓음
        talkData.Add(104, new string[] { "...어차피 대중은 개돼지야...:0" });//벼 다시 누를때
        InteractData.Add(100, InteractArr[4]); // 교만 제외 벼 그림 
        InteractData.Add(101, InteractArr[4]);
        InteractData.Add(103, InteractArr[10]);
        InteractData.Add(104, InteractArr[11]);

        talkData.Add(200, new string[] { "시계가 5시 40분을 가리키고 있다.:0" });//교만 제외 시계
        talkData.Add(201, new string[] { "시계 밑에 작은 글씨로 5시 40분이 적혀 있다.:0" });//시계
        talkData.Add(202, new string[] { "이렇게 해도 5시 40분이라고 할 수 있을까." });//시계2
        InteractData.Add(200, InteractArr[5]);
        InteractData.Add(201, InteractArr[5]);

        talkData.Add(300, new string[] { "바닥에 단단하게 붙어있다." });// 교만 제외 시크릿 열쇠
        talkData.Add(304, new string[] { "뭐야, 주울 수 있었잖아?:0" });//시크릿 열쇠
        InteractData.Add(304, InteractArr[6]);


        talkData.Add(400, new string[] { "어울리지 않게 리어카와 귀여운 곰인형이 함께 있다:0" });// 교만 제외 곰인형
        talkData.Add(401, new string[] { "어울리지 않게 리어카와 귀여운 곰인형이 함께 있다:0" }); // 곰인형
        talkData.Add(402, new string[] { "곰인형이 넘어졌다.:0" });
        talkData.Add(404, new string[] { "벽에 동그란 뭔가가 박혀있다."});
        talkData.Add(405, new string[] { "벽에 동그란 뭔가가 박혀있다.", "오래된 열쇠인 것 같다." });
        InteractData.Add(400, InteractArr[7]);// 교만 제외 곰인형 화면
        InteractData.Add(401, InteractArr[7]);
        InteractData.Add(402, InteractArr[7]);

        talkData.Add(500, new string[] { "웬 석상?:0" });
        InteractData.Add(500, InteractArr[8]);
        talkData.Add(501, new string[] { "무거워 보인다.:0" }); // 아틀라스 석상
        InteractData.Add(501, InteractArr[8]);
        talkData.Add(502, new string[] { "돌을 떨어뜨리게 했다.:0" }); // 아틀라스 석상 item1 아이템 보유시 변경대사 테스트
        InteractData.Add(502, InteractArr[8]);

        talkData.Add(600, new string[] { "체스판만 덩그러니 놓여있다.:0" }); // 교만 제외 체스판
        InteractData.Add(600, InteractArr[12]);
        talkData.Add(601, new string[] { "보통 이 반대로 돼 있지 않나?:0" }); //체스판
        InteractData.Add(601, InteractArr[12]);
        talkData.Add(602, new string[] { "역시 킹이 제일 뒤로 와야지.:0" }); //체스판 미션 후 
        InteractData.Add(602, InteractArr[12]);

        //talkData.Add(402, new string[] { "작은 수레에 걸쇠가 걸려있다." });//수레

        //talkData.Add(270, new string[] { "이렇게 해도 5시 40분인건가.." });//시계 2
        //talkData.Add(280, new string[] { "바위다." });//바위

        talkData.Add(510, new string[] { "학생들..인가?:0" });
        InteractData.Add(510, InteractArr[9]);
        talkData.Add(520, new string[] { "어딘가 수상해보이는 사람들이다.:0" });
        InteractData.Add(520, InteractArr[15]);
        talkData.Add(530, new string[] { "사람들이 시위를 하는 모습이 담겨있다.:0" });
        InteractData.Add(530, InteractArr[13]);
        talkData.Add(540, new string[] { "진짜 사람을 죽인건가?..:0" });
        InteractData.Add(540, InteractArr[16]);
        talkData.Add(550, new string[] { "깜짝이야.. 교통사고가 난 모습이다:0" });
        InteractData.Add(550, InteractArr[14]);
        talkData.Add(560, new string[] { "...진짜 뛰어내렸을까?:0" });
        InteractData.Add(560, InteractArr[18]);



        //npc 천번대부터 시작
        talkData.Add(1000, new string[] { "이게 무슨 일이지?:0", "나도 모르겠어... 그저 자리를 지키고 있을 뿐:0" }); //  인색
        talkData.Add(1001, new string[] { "자유롭게 좀 더 높이 올라가고 싶었어:0", "목적없는 질주는 자유가 아니라 주인없는 말일 뿐이야:0" });
        talkData.Add(1010, new string[] { "호기심은 언제나 위험하지..:0", "호기심을 가지는 건 죄일까 아닐까:0" }); // 탐욕
        talkData.Add(1011, new string[] { "구름에 다가가고자 뒷다리가 생겼지만\n하늘은 너무 높았어:0", "어쩌면 우물안 개구리의 허영이었을지도:0" });
        talkData.Add(1020, new string[] { "너무 으스스하지 않아?:0", "난 항상 추워...:0" }); // 시기
        talkData.Add(1021, new string[] { "난 항상 추웠어. 그래서 모두가 따뜻해보였지.:0", "그 뜨거운 열기에 취해 넌 스스로를 가둔거야.:0" });
        talkData.Add(1030, new string[] { "치마를 입기에는 너무 추워 보이는데.:0", "난 아직도 뜨거워. 그래서 뜨거운게 필요해:0" }); // 음욕
        talkData.Add(1040, new string[] { "우린 무슨 죄를 짓고 여기에 온 걸까..?:0", "그건 아무도 모르지만 확실한 건\n너랑 나는 똑같다는 것.:0" }); //분노
        talkData.Add(1050, new string[] { "수염을 멋지게도 기르시네요.:0", "더 이상 깎지 않아도 된다는 장점도 있다네.:0" }); // 태만
        talkData.Add(1060, new string[] { "내가 안 보이나..?:0" }); //교만 npc 대사

        //초상화
        portraitData.Add(1000, portraitArr[0]);
        portraitData.Add(1001, portraitArr[0]);
        portraitData.Add(1010, portraitArr[1]);
        portraitData.Add(1011, portraitArr[1]);
        portraitData.Add(1020, portraitArr[2]);
        portraitData.Add(1021, portraitArr[2]);
        portraitData.Add(1030, portraitArr[3]);
        portraitData.Add(1040, portraitArr[4]);
        portraitData.Add(1050, portraitArr[5]);
        portraitData.Add(1060, portraitArr[4]); // 교만 초상화 (임시로 4번으로 넣음)

        //분노 관련 오브젝트들
        talkData.Add(2010, new string[] { "이건 뭐지?:0" });
        InteractData.Add(2010, InteractArr[17]);
        talkData.Add(2011, new string[] { "중간에 뭔가 써 넣어야 하나?:0" });
        InteractData.Add(2011, InteractArr[17]);
        talkData.Add(2012, new string[] { "이렇게 하면 모두 말이 된다:0" });
        InteractData.Add(2012, InteractArr[17]);

        talkData.Add(2015, new string[] { "피가 잔뜩 묻은 사원증이다." });

        talkData.Add(2100, new string[] { "사람 모형 두개가 서로 붙어있다.:0" });
        InteractData.Add(2100, InteractArr[17]);
        talkData.Add(2101, new string[] { "한 쪽 모형이 치사하게 칼을 들고있다:0" });
        InteractData.Add(2101, InteractArr[17]);
        talkData.Add(2102, new string[] { "반격 시간이다 작은 친구.:0" });
        InteractData.Add(2102, InteractArr[17]);

        talkData.Add(2200, new string[] { "햇빛이 뜨거워보인다.:0" });
        InteractData.Add(2200, InteractArr[20]);
        talkData.Add(2201, new string[] { "햇빛이 뜨거워보인다.:0" });
        InteractData.Add(2201, InteractArr[20]);
        talkData.Add(2202, new string[] { "!!.. 갑자기 사진이 변했다.:0", "늑대..인간처럼 보인다.:0" });
        InteractData.Add(2202, InteractArr[21]);
        talkData.Add(2203, new string[] { "늑대..인간처럼 보인다.:0" });
        InteractData.Add(2203, InteractArr[21]);
        talkData.Add(2205, new string[] { "수상한 액체가 담긴 병이다." });


        talkData.Add(2300, new string[] { "작동이 되지 않는 플래시라이트다." });
        talkData.Add(2301, new string[] { "나름 새 것 같은 플래시라이트다." });
        talkData.Add(2305, new string[] { "수첩..?:0" });
        InteractData.Add(2305, InteractArr[19]);


        talkData.Add(2400, new string[] { "두 개의 비커가 놓여 있다.:0" });
        InteractData.Add(2400, InteractArr[17]);
        talkData.Add(2401, new string[] { "비커가 두 개 있다.:0" });
        InteractData.Add(2401, InteractArr[17]);
        talkData.Add(2402, new string[] { "모두 채운 것 같다.:0" });
        InteractData.Add(2402, InteractArr[17]);

        talkData.Add(2405, new string[] { "흙탕물을 얻었다.:0" });
        InteractData.Add(2405, InteractArr[22]);
        talkData.Add(2406, new string[] { "징그러운 뱀이 담긴 술이다.:0" });
        InteractData.Add(2406, InteractArr[23]);

        talkData.Add(2500, new string[] { "라이터가 떨어져 있다." });
        talkData.Add(2501, new string[] { "라이터가 떨어져 있다." });
   
        talkData.Add(2504, new string[] { "식어있는 벽난로다.:0" });
        InteractData.Add(2504, InteractArr[24]);
        talkData.Add(2505, new string[] { "식어있는 벽난로다.:0" });
        InteractData.Add(2505, InteractArr[24]);
        talkData.Add(2506, new string[] { "라이터로 벽난로에 불을 붙였다.:0" });
        InteractData.Add(2506, InteractArr[24]);
        talkData.Add(2507, new string[] { "불이 활활 타고있다.:0" });
        InteractData.Add(2507, InteractArr[24]);
        talkData.Add(2508, new string[] { "흙탕물을 끼얹어 불을 껐다.:0" });
        InteractData.Add(2508, InteractArr[24]);
        talkData.Add(2509, new string[] { "불이 꺼진 벽난로다..:0" });
        InteractData.Add(2509, InteractArr[24]);

        // 음욕 관련 옵젝 대사들
        talkData.Add(1012, new string[] { "명품백?" });

        talkData.Add(4010, new string[] { "격노팀장..? 누구의 명함이지?:0" });
        InteractData.Add(4010, InteractArr[25]);


        talkData.Add(4100, new string[] { "누군가 말을 타고 있는 그림이다.:0" });
        InteractData.Add(4100, InteractArr[30]);
        talkData.Add(4101, new string[] { "누군가 말을 타고 있는 그림이다.:0" });
        InteractData.Add(4101, InteractArr[30]);
        talkData.Add(4102, new string[] { "유니콘의 뿔을 획득했다.:0" });
        InteractData.Add(4102, InteractArr[30]);
        talkData.Add(4103, new string[] { "말에서 떨어진 것 같다.:0" });
        InteractData.Add(4103, InteractArr[31]);


        talkData.Add(4300, new string[] { "오래된 망치가 놓여있다." });
        talkData.Add(4301, new string[] { "오래된 망치를 찾았다." });

        talkData.Add(4305, new string[] { "어항에 올챙이 한 마리가 있다.:0" });
        InteractData.Add(4305, InteractArr[26]);
        talkData.Add(4306, new string[] { "와장창!!:0","망치로 어항을 깨버렸다.:0" });
        InteractData.Add(4306, InteractArr[26]);
        talkData.Add(4307, new string[] { "개구리가 튀어나왔다!:0" });
        InteractData.Add(4307, InteractArr[27]);

        talkData.Add(4500, new string[] { "크기는 작지만 정말 뜨거운 화산이다.:0" });
        InteractData.Add(4500, InteractArr[28]);
        talkData.Add(4501, new string[] { "평범한 화산이다.:0" });
        InteractData.Add(4501, InteractArr[28]);
        talkData.Add(4502, new string[] { "화산이 폭발하고 있다..!:0" });
        InteractData.Add(4502, InteractArr[29]);


    }

    public string GetTalk(int id, int talkindex)
    {
        if (talkindex == talkData[id].Length)
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
