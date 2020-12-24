using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 말걸기, 텍스트 표시 및 넘기기 관련 코드가 들어있음.

public class GameManager : MonoBehaviour
{
    public TalkManger talkmanager;
    public GameObject talkpanel;
    GameObject Luxuria;
    public Image portraitimg, Interactimg;
    public TalkAnimation talk;
    public GameObject scanObject,IManager,ActManager,CManager,DManager,TManager;
    public bool istalking;
    public int talkindex;
    public Text npcname;
    public List<int> items = new List<int>();
    // 죄 선택 >> MissionManager의 Sin 전역변수로 사용

    // Start is called before the first frame update

    public void Action(GameObject scanObj)
    {
        
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Debug.Log(objData.id +","+ objData.isNpc+","+objData.isItem);
        
        if (objData.id != 301 && objData.id != 302 && objData.id != 303) // 3번방 열쇠 3번 누르는 동안 반응 없도록 하는 조건
        {
            Talk(objData.Interactive, objData.id, objData.isNpc, objData.isItem, objData.SinNumber, objData.isShared);
            talkpanel.SetActive(istalking);
        }
        else objData.id++; // 3번방 열쇠에 해당하는 코드
    }


    void Talk(bool isInter,int id, bool isNpc, bool isItem,int SinNumber,bool isShared)
    {
        
        string talkData = "";
        if (talk.isTyping)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            if (SinNumber != MissionManager.Sin && !isShared)
            {
                    talkData = talkmanager.GetTalk(id - 1, talkindex);
            }
            else
            {
                talkData = talkmanager.GetTalk(id, talkindex);
            }
            ActManager.GetComponent<InteractManager>().Interact(id);
        }
        if (talkData==null )
        {
            ActManager.GetComponent<InteractManager>().EndInteract(id);
            if (isItem)
            {
                
                int icode = scanObject.GetComponent<ObjectData>().itemcode;

                if (id == 998) //id가 998이면 해당 오브젝트가 열 수 있는 문이라는 뜻. 
                {
                    int DoorIndex0 = scanObject.GetComponent<DoorObject>().DoorIndex; //문 코드를 불러와서
                    
                    DManager.GetComponent<DoorManager>().DoorOpen(DoorIndex0); //해당하는 문을 열어준다
                }

                if (icode > 0&&(SinNumber==MissionManager.Sin||isShared)) // 아이템코드가 1 이상이면 획득 가능한 아이템이다
                {
                    
                    if(id!=3) scanObject.SetActive(false);
                    if (CManager.GetComponent<CameraManager>().CheckItem(icode) == 1) // 아이템을 갖고 있다면
                    {
                        CManager.GetComponent<CameraManager>().UseItem(icode); // 유즈 아이템을 실행하고
                    }
                    else if (CManager.GetComponent<CameraManager>().CheckItem(icode) == 0)// 가지고 있지 않다면
                    {
                        CManager.GetComponent<CameraManager>().GetItem(icode); // 겟 아이템을 실행한다.
                    }
                }
            }
            istalking = false;
            talkindex = 0;
            return;
        }
        if(isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);
            portraitimg.sprite = talkmanager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            
            portraitimg.color = new Color(1, 1, 1, 1);
            Interactimg.color = new Color(1, 1, 1, 0);
            if (talkindex % 2 == 1)
            {
                string npcName = scanObject.name;
                npcname.text = npcName;
            }
            else
            {
                npcname.text = "Player";
            }
        }
        else if (isInter)
        {
            if (SinNumber != MissionManager.Sin && !isShared)
            {
                    Interactimg.sprite = talkmanager.GetInteract(id - 1, int.Parse(talkData.Split(':')[1]));
            }
            else
            {
                Interactimg.sprite = talkmanager.GetInteract(id, int.Parse(talkData.Split(':')[1]));
            }
                Interactimg.color = new Color(1, 1, 1, 1);
                portraitimg.color = new Color(1, 1, 1, 0);
                talk.SetMsg(talkData.Split(':')[0]);
            

        }
        else
        {
            portraitimg.color = new Color(1, 1, 1, 0);
            Interactimg.color = new Color(1, 1, 1, 0);
            npcname.text = "Player";
            talk.SetMsg(talkData);
        }

        istalking = true;
        talkindex++;
        
    }
    
    public Text timer;
    float time, time1, time2;
    void Start()
    {
        DManager=GameObject.Find("DoorManager");
        ActManager = GameObject.Find("InteractManager");
        CManager = GameObject.Find("CameraManager");
        TManager = GameObject.Find("TManager");
        talkpanel.SetActive(false);
        timer = GameObject.Find("Timer").GetComponent<Text>();
        time = 2; // 초 시간
        time1 = 24; // 분
        time2 = 20; 
        Luxuria = GameObject.Find("Luxuria"); // 가만히 있으면 대사를 띄우기 위한 Empty 오브젝트.

        
    }

    // Update is called once per frame
    void Update()
    { 
        
        time -= Time.deltaTime;
        if (MissionManager.Sin == 2)
        {
            if (CManager.GetComponent<CameraManager>().CheckItem(2) == 0)
            {
                time2 -= Time.deltaTime;
            }
        }
        if (time < -0.4) //초가 0이 되면 60초로 초기화, 분 감소
        {
            time = 59.4f;
            time1--;
            if (time1 == 22) // 1분동안 아무것도 상호작용하지 않으면 음욕으로 자동선택
            {
                if (MissionManager.Sin == 0) 
                {
                    Action(Luxuria);
                    Luxuria.transform.position = CameraManager.Camlocation;
                }
            }
            if (time1 == 12) // 남은시간이 절반이 되면 4,5,6번방 문이 열린다.
            {
                DManager.GetComponent<DoorManager>().Door456Open();

            }

        }
        if (time2 <= 0)
        {
            GameObject.Find("MissionManager").GetComponent<MissionManager>().ShowIDcard();
            time2 = 30;
        }
        
        timer.text = string.Format(time1+":{00:N0}", time);
    }

    public void Starttime()
    {
        time2 = 10;
    }

    public void DisableLux()
    {
        Luxuria.SetActive(false);
    }
}
