using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    GameObject MManager,CManager;
    public int intcounter, interacting;
    // Start is called before the first frame update
    void Start()
    {
        CManager = GameObject.Find("CameraManager");
        MManager=GameObject.Find("MissionManager");
        intcounter = 0;
        interacting = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void Interact(int objid) // 모든 오브젝트와 상호작용지 id에따라 부수적으로 작동할 부분들
    {
        if (interacting == 0)
        {
            intcounter++;
            Debug.Log("인터랙트가" + intcounter + "회 실행되었습니다.");
            switch (objid)
            {
                case 3:
                    MManager.GetComponent<MissionManager>().DrawerOn();
                    break;
                case 101:
                    if (CManager.GetComponent<CameraManager>().CheckItem(4) == 0)
                    {
                        CManager.GetComponent<CameraManager>().Sun.SetActive(true);
                    }
                    break;
                case 102:
                    CManager.GetComponent<CameraManager>().mealart.GetComponent<ObjectData>().id = 103;
                    break;
                case 103:
                    CManager.GetComponent<CameraManager>().mealart.GetComponent<ObjectData>().id = 104;
                    break;


                case 201: // 
                    MManager.GetComponent<MissionManager>().ClockOn();
                    break;
                case 401: // 
                    MManager.GetComponent<MissionManager>().CartOn();
                    break;
                case 402: // 
                    MManager.GetComponent<MissionManager>().CartOn();
                    break;
                case 501: // 
                    MManager.GetComponent<MissionManager>().AtlasOn();
                    break;
                case 502: // 
                    MManager.GetComponent<MissionManager>().AtlasOn();
                    break;
                case 601: // 
                    MManager.GetComponent<MissionManager>().ChessOn();
                    break;
                case 602: // 
                    MManager.GetComponent<MissionManager>().ChessOn();
                    break;
                case 997:
                    Debug.Log("열린 문 입니다.");
                    break;

                case 1010:
                    CManager.GetComponent<CameraManager>().DevilScaleUp();
                    break;
                case 1020:
                    CManager.GetComponent<CameraManager>().DevilScaleUp();
                    break;
                case 1030:
                    CManager.GetComponent<CameraManager>().DevilScaleUp();
                    break;
                case 1040:
                    break;


            }
        }
        interacting = 1;
    }

    public void EndInteract(int objid)
    {
        if (interacting == 1)
        {
            switch (objid)
            {
                case 3:
                    MManager.GetComponent<MissionManager>().DrawerOff();
                    break;
                case 12:
                    if (CManager.GetComponent<CameraManager>().CheckItem(7) == 0)
                    {
                        MManager.GetComponent<MissionManager>().INodong.SetActive(true);
                    }
                    break;
                case 997:
                    Debug.Log("열린 문과의 대화가 종료되었습니다.");
                    break;
                case 201:
                    MManager.GetComponent<MissionManager>().ClockOff();
                    
                    break;
                case 401: // 
                    MManager.GetComponent<MissionManager>().CartOff();
                    break;
                case 402: // 
                    MManager.GetComponent<MissionManager>().CartOff();
                    break;
                case 501: // 
                    MManager.GetComponent<MissionManager>().AtlasOff();
                    break;
                case 502: // 
                    MManager.GetComponent<MissionManager>().AtlasOff();
                    break;
                case 601: // 
                    MManager.GetComponent<MissionManager>().ChessOff();
                    break;
                case 602: // 
                    MManager.GetComponent<MissionManager>().ChessOff();
                    break;
            }
        }
        interacting = 0;
    }

}
