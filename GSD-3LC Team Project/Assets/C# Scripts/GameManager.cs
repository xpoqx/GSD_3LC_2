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
    public GameObject scanObject;
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
        if (objData.id != 301 && objData.id != 302 && objData.id != 303)
        {
            Talk(objData.Interactive, objData.id, objData.isNpc, objData.isItem);
            talkpanel.SetActive(istalking);
        }
        else objData.id++;

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
        }
        if (id == 201)
        {
            GameObject.Find("CameraManager").GetComponent<CameraManager>().onClock = 1;
        }
        if (talkData==null )
        {
            if (isItem)
            {
                GameObject CManager = GameObject.Find("CameraManager");
                
                int itemcode = scanObject.GetComponent<ObjectData>().itemcode;
                if (id == 998)
                {
                    int DoorIndex0 = scanObject.GetComponent<DoorObject>().DoorIndex;
                    int have = CManager.GetComponent<CameraManager>().CheckItem(DoorIndex0);
                    if (have == 1)
                    {
                        GameObject.Find("DoorManager").GetComponent<DoorManager>().DoorOpen(DoorIndex0);
                    }
                }
                if (itemcode > 0 )
                {
                    scanObject.SetActive(false);
                    if (CManager.GetComponent<CameraManager>().CheckItem(itemcode) == 1)
                    {
                        CManager.GetComponent<CameraManager>().UseItem(itemcode);
                    }
                    else
                    {
                        CManager.GetComponent<CameraManager>().GetItem(itemcode);
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
    float time;
    void Start()
    {
        talkpanel.SetActive(false);
        timer = GameObject.Find("Timer").GetComponent<Text>();
        time = 10;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.text = string.Format("{00:N1}", time);
    }
}
