using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    GameObject MManager;
    public int intcounter, interacting;
    // Start is called before the first frame update
    void Start()
    {
        MManager=GameObject.Find("MissionManager");
        intcounter = 0;
        interacting = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void Interact(int objid)
    {
        if (interacting == 0)
        {
            intcounter++;
            Debug.Log("인터랙트가" + intcounter + "회 실행되었습니다.");
            switch (objid)
            {
                case 997:
                    Debug.Log("열린 문 입니다.");
                    break;
                case 201:
                    MManager.GetComponent<MissionManager>().SetClockVisible();
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
                case 997:
                    Debug.Log("열린 문과의 대화가 종료되었습니다.");
                    break;
                case 201:
                    MManager.GetComponent<MissionManager>().SetClockInvisible();
                    
                    break;
            }
        }
        interacting = 0;
    }

}
