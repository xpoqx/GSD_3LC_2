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
    private GameObject manekingapple;


    // Start is called before the first frame update

    public void Action(GameObject scanObj)
    {

        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Debug.Log(objData.id +","+ objData.isNpc+","+objData.isItem);
        //if (objData.id==200)
        //{
        //    haveitem();
        //    SpecialAction(objData);
        //}
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
                int itemcode = scanObject.GetComponent<ObjectData>().itemcode;
                if (itemcode > 0)
                {
                    GameObject.Find("ItemManager").GetComponent<ItemManager>().GetItem(itemcode);
                    if (itemcode != 7)
                    {
                        scanObject.SetActive(false);
                    }
                    if (itemcode == 7)
                    {
                        manekingapple.SetActive(true);
                    }
                }
                
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
    void Start()
    {
        talkpanel.SetActive(false);
        manekingapple=GameObject.Find("마네킹사과");
        manekingapple.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
