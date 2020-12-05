using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManger talkmanager;
    public GameObject talkpanel;
    public TalkAnimation talk;
    public GameObject scanObject;
    public bool istalking;
    public int talkindex;
    public Text npcname;
    public List<int> items = new List<int>();
    public bool haveitem1;//, haveitem2, haveitem3, haveitem4, haveitem5;
    GameObject item1;//, item2, item3, item4, item5;


    // Start is called before the first frame update

    public void Action(GameObject scanObj)
    {

        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Debug.Log(objData.id +","+ objData.isNpc);
        if (objData.id==200)
        {
            haveitem();
            SpecialAction(objData);
        }
        Talk(objData.id, objData.isNpc, objData.isItem);
        talkpanel.SetActive(istalking);
    }


    void Talk(int id, bool isNpc, bool isItem)
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
        
        if (talkData==null )
        {
            if (isItem)
            {
                scanObject.SetActive(false);
            }
            istalking = false;
            talkindex = 0;
            return;
        }
        if(isNpc)
        {
            talk.SetMsg(talkData);
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
        else
        {
            npcname.text = "Player";
            talk.SetMsg(talkData);
        }
        if(isItem)
        {
            getitem(1);
            showitem();
        }

        istalking = true;
        talkindex++;
    }
    public void getitem(int index)
    {

        items.Add(1);
    }

    public void showitem()
    {
        if (items[0] == 1)
        {
            item1.SetActive(true);
        }
        /*if (items[1] == 1)
        {
            item2.SetActive(true);
        }
        if (items[2] == 1)
        {
            item3.SetActive(true);
        }
        if (items[3] == 1)
        {
            item4.SetActive(true);
        }
        if (items[4] == 1)
        {
            item5.SetActive(true);
        }*/
        Debug.Log(items[0]);
    }
    public void haveitem()
    {
        if(item1.activeSelf==true)
        {
            haveitem1 = true;
        }
        else
        {
            haveitem1 = false;
        }
    }
    public int SpecialAction(ObjectData objData)
    {
        if (haveitem1)
        {
            objData.id += 1;
            return objData.id;
        }
        else
        {
            return objData.id;
        }

    }
    void Start()
    {
        talkpanel.SetActive(false);
        haveitem1 = false;
        item1 = GameObject.Find("item1");
        item1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
