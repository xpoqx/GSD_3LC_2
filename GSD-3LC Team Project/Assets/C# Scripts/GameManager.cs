using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManger talkmanager;
    public GameObject talkpanel;
    public Image portraitimg, Interactimg;
    public TalkAnimation talk;
    public GameObject scanObject,IManager,ActManager,CManager,DManager;
    public bool istalking;
    public int talkindex;
    public Text npcname;
    public List<int> items = new List<int>();
    


    // Start is called before the first frame update

    public void Action(GameObject scanObj)
    {
        
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Debug.Log(objData.id +","+ objData.isNpc+","+objData.isItem);
        
        if (objData.id != 301 && objData.id != 302 && objData.id != 303) // 3번방 열쇠 3번 누르는 동안 반응 없도록 하는 조건
        {
            Talk(objData.Interactive, objData.id, objData.isNpc, objData.isItem);
            talkpanel.SetActive(istalking);
        }
        else objData.id++; // 3번방 열쇠에 해당하는 코드
    }


    void Talk(bool isInter,int id, bool isNpc, bool isItem)
    {
        
        string talkData = "";
        if (talk.isTyping)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            talkData = talkmanager.GetTalk(id, talkindex);
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

                if (icode > 0) // 아이템코드가 1 이상이면 획득 가능한 아이템이다
                {
                    scanObject.SetActive(false);
                    if (CManager.GetComponent<CameraManager>().CheckItem(icode) == 1) // 아이템을 갖고 있다면
                    {
                        CManager.GetComponent<CameraManager>().UseItem(icode); // 유즈 아이템을 실행하고
                    }
                    else // 가지고 있지 않다면
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
            
            Interactimg.sprite = talkmanager.GetInteract(id, int.Parse(talkData.Split(':')[1]));
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
        //if(isItem)
        //{
        //    getitem(1);
        //    showitem();
        //}

        istalking = true;
        talkindex++;
        
    }

    //public int SpecialAction(ObjectData objData)
    //{
    //    if (haveitem1)
    //    {
    //        objData.id += 1;
    //        return objData.id;
    //    }
    //    else
    //    {
    //        return objData.id;
    //    }

    //}
    public Text timer;
    float time, time1;
    void Start()
    {
        DManager=GameObject.Find("DoorManager");
        ActManager = GameObject.Find("InteractManager");
        CManager = GameObject.Find("CameraManager");
        talkpanel.SetActive(false);
        timer = GameObject.Find("Timer").GetComponent<Text>();
        time = 10; // 초 시간
        time1 = 24; // 분
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < -0.4) //초가 0이 되면 60초로 초기화, 분 감소
        {
            time = 59.4f;
            time1--;
            if (time1 == 23)
            {
                DManager.GetComponent<DoorManager>().Door456Open();
            }
        }
        
        timer.text = string.Format(time1+":{00:N0}", time);
    }
}
