using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    GameObject MManager,CManager,GManager,DManager,PManager;
    public int intcounter, interacting;
    GameObject Npc0, Npc1, Npc2, Npc3, GlassObj, Volcano, Horse;
    int C0, C1, C2, C3;
    
    // Start is called before the first frame update
    void Start()
    {
        CManager = GameObject.Find("CameraManager");
        MManager=GameObject.Find("MissionManager");
        GManager = GameObject.Find("GameManager");
        DManager = GameObject.Find("DoorManager");
        PManager = GameObject.Find("PlayerController");
        Npc0 = GameObject.Find("NPC0");
        Npc1 = GameObject.Find("NPC1");
        Npc2 = GameObject.Find("NPC2");
        Npc3 = GameObject.Find("NPC3");
        GlassObj = GameObject.Find("GlassObj");
        Volcano = GameObject.Find("Volcano");
        Horse = GameObject.Find("Horse");
        C0 = 1; C1 = 1; C2 = 1;
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
                case 10000:
                    if (MissionManager.Sin == 0)
                    {
                        MissionManager.Sin = 3;
                    }
                    DManager.GetComponent<DoorManager>().DoorOpen(1);
                    break;
                case 3:
                    MissionManager.Sin = 1;
                    break;
                case 5:
                    if (MissionManager.Sin == 0)
                    {
                        MissionManager.Sin = 2;
                    }
                    break;
                case 101:
                    if (MissionManager.Sin == 1)
                    {
                        if (CManager.GetComponent<CameraManager>().CheckItem(4) == 0)
                        {
                            CManager.GetComponent<CameraManager>().Sun.SetActive(true);
                        }
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

                
                case 1040:
                    break;

                    //분노 관련 시작

                case 2011: 
                    MManager.GetComponent<MissionManager>().PuzzleMainOn();
                    break;
                case 2101:
                    MManager.GetComponent<MissionManager>().Ira1On();
                    break;
                case 2102:
                    MManager.GetComponent<MissionManager>().Ira1On();
                    break;
                case 2201:
                    MManager.GetComponent<MissionManager>().Ira2On();
                    break;
                case 2401:
                    MManager.GetComponent<MissionManager>().Ira4On();
                    break;
                case 2402:
                    MManager.GetComponent<MissionManager>().Ira4On();
                    break;
                case 2505:

                    MManager.GetComponent<MissionManager>().Ira5On();

                    break;
                case 2506:
                    MManager.GetComponent<MissionManager>().Ira5On();
                    break;
                case 2507:
                    MManager.GetComponent<MissionManager>().Ira5On();
                    break;
                case 2508:
                    MManager.GetComponent<MissionManager>().Ira5On();
                    break;
                case 2509:
                    MManager.GetComponent<MissionManager>().Ira5On();
                    break;


                case 4101:
                    MManager.GetComponent<MissionManager>().UniOn();
                    break;
                case 4305:
                    MManager.GetComponent<MissionManager>().Lux3On();
                    break;
                case 4306:
                    MManager.GetComponent<MissionManager>().Lux3On();
                    break;
                case 4307:
                    MManager.GetComponent<MissionManager>().Lux3On();
                    break;
                case 4501:
                    MManager.GetComponent<MissionManager>().VolcanoOn();
                    break;
                case 4502:
                    MManager.GetComponent<MissionManager>().VolcanoOn();
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
                case 10000:
                    GManager.GetComponent<GameManager>().DisableLux();

                    break;
                case 3:
                    MManager.GetComponent<MissionManager>().DrawerOn();
                    break;
                case 5:
                    if (MissionManager.Sin == 2)
                    {
                        MManager.GetComponent<MissionManager>().WallOn();
                    }
                    break;
                case 6:
                    MManager.GetComponent<MissionManager>().WallOn();
                    break;
                case 12:
                    if (MissionManager.Sin == 1)
                    {
                        if (CManager.GetComponent<CameraManager>().CheckItem(7) == 0)
                        {
                            MManager.GetComponent<MissionManager>().INodong.SetActive(true);
                        }
                    }
                    if (MissionManager.Sin == 3)
                    {
                        if (CManager.GetComponent<CameraManager>().CheckItem(4) == 0)
                        {
                            MManager.GetComponent<MissionManager>().Appled();
                        }
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
                case 560:
                    DManager.GetComponent<DoorManager>().Door123Open();
                    break;
                case 601: // 
                    MManager.GetComponent<MissionManager>().ChessOff();
                    break;
                case 602: // 
                    MManager.GetComponent<MissionManager>().ChessOff();
                    break;

                //분노 관련 시작

                case 2011:
                    MManager.GetComponent<MissionManager>().PuzzleMainOff();
                    break;
                case 2101:
                    MManager.GetComponent<MissionManager>().Ira1Off();
                    break;
                case 2102:
                    MManager.GetComponent<MissionManager>().Ira1Off();
                    break;
                case 2201:
                    MManager.GetComponent<MissionManager>().Ira2Off();
                    break;
                case 2401:
                    MManager.GetComponent<MissionManager>().Ira4Off();
                    break;
                case 2402:
                    MManager.GetComponent<MissionManager>().Ira4Off();
                    break;
                case 2505:
                    MManager.GetComponent<MissionManager>().Ira5Off();
                    break;
                case 2506:
                    MManager.GetComponent<MissionManager>().Ira5Off();
                    break;
                case 2507:
                    MManager.GetComponent<MissionManager>().Ira5Off();
                    break;
                case 2508:
                    MManager.GetComponent<MissionManager>().Ira5Off();
                    break;
                case 2509:
                    MManager.GetComponent<MissionManager>().Ira5Off();
                    break;


                case 1000:
                    if (MissionManager.Sin == 3) 
                    {
                        if (Horse.GetComponent<ObjectData>().id == 4103 && C0 < 2)
                        {
                            C0++;
                        }
                        if (C0 == 2)
                        {
                            Npc0.GetComponent<ObjectData>().id = 1001;
                        }

                    }
                    break;
                case 1001:
                    MManager.GetComponent<MissionManager>().GiveItem(7);
                    break;

                case 1010:
                    if (MissionManager.Sin == 3)
                    {
                        if(GlassObj.GetComponent<ObjectData>().id == 4307&&C1<3)
                        {
                            C1++;
                        }
                        else if(C1 == 3)
                        {
                            Npc1.GetComponent<ObjectData>().id = 1011;
                        }

                    }
                    break;
                case 1011:
                    MManager.GetComponent<MissionManager>().GiveItem(1);
                    break;
                case 1020:
                    if (MissionManager.Sin == 3)
                    {
                        if (Volcano.GetComponent<ObjectData>().id == 4502 && C2 < 5)
                        {
                            C2++;
                        }
                        else if (C2 == 5)
                        {
                            Npc2.GetComponent<ObjectData>().id = 1021;
                        }
                    }
                    break;
                case 1021:
                    MManager.GetComponent<MissionManager>().GiveItem(10);
                    break;
                case 1030:
                    if (MissionManager.Sin == 3)
                    {

                    }
                    break;
                case 4101:
                    MManager.GetComponent<MissionManager>().UniOff();
                    break;
                case 4305:
                    MManager.GetComponent<MissionManager>().Lux30Off();
                    break;
                case 4306:
                    MManager.GetComponent<MissionManager>().Lux30Off();
                    break;
                case 4307:
                    MManager.GetComponent<MissionManager>().Lux30Off();
                    break;

                case 4501:
                    MManager.GetComponent<MissionManager>().VolcanoOff();
                    break;
                case 4502:
                    MManager.GetComponent<MissionManager>().VolcanoOff();
                    break;
            }

        }
        interacting = 0;

    }

}
