using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManger talkmanager;
    public GameObject talkpanel;
    public Text talktxt;
    public GameObject scanObject;
    public bool istalking;
    public int talkindex;

    // Start is called before the first frame update

    public void Action(GameObject scanObj)
    {

        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc);
        talkpanel.SetActive(istalking);
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = talkmanager.GetTalk(id, talkindex);
        
        if (talkData==null)
        {
            istalking = false;
            talkindex = 0;
            return;
        }
        if(isNpc)
        {
            talktxt.text = talkData;
        }
        else
        {
            talktxt.text = talkData;
        }

        istalking = true;
        talkindex++;
    }
    void Start()
    {
        talkpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
