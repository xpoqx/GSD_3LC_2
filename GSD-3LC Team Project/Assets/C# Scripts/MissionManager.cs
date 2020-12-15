using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    GameObject Hour, Minute,Clock1,Clock2;
    public Vector3 Camloc; //카메라 위치
    public int onClockMission,HourDegree,MinuteDegree;
    // Start is called before the first frame update
    void Start()
    {
        Hour = GameObject.Find("Hour");
        Minute = GameObject.Find("Minute");
        Clock1 = GameObject.Find("Clock1");
        Clock2 = GameObject.Find("Clock2");
        //Hour.SetActive(false);
        //Minute.SetActive(false);
        Clock2.SetActive(false);
        onClockMission = 0;
        HourDegree = 2;
        MinuteDegree = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Camloc = CameraManager.Camlocation;
        

        if (onClockMission == 1)
        {
            Hour.transform.position = new Vector3(Camloc.x + 0.1f, Camloc.y + 1.25f, 1);
            Minute.transform.position = new Vector3(Camloc.x + 0.1f, Camloc.y + 1.25f, 1);
            Hour.transform.localScale = new Vector3(0.4f, 0.4f, 1);
            Minute.transform.localScale = new Vector3(0.4f, 0.4f, 1);
            if (Input.GetMouseButtonDown(0))
            {
                HourDegree++;
                if (HourDegree > 11)
                {
                    HourDegree = 0;
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                MinuteDegree++;
                if (MinuteDegree > 11)
                {
                    MinuteDegree = 0;
                }
            }
            Minute.transform.rotation = Quaternion.Euler(0, 0, MinuteDegree * (-30));
            Hour.transform.rotation = Quaternion.Euler(0, 0, HourDegree * (-30));
        }
        else
        {
            Hour.transform.position = new Vector3(56.02f,20.92f, 1);
            Minute.transform.position = new Vector3(56.02f, 20.92f, 1);
            Hour.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            Minute.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        }

    }

    public void SetClockVisible()
    {
        //Hour.SetActive(true);
        //Minute.SetActive(true);
        onClockMission = 1;
    }
    public void SetClockInvisible()
    {
        //Hour.SetActive(false);
        //Minute.SetActive(false);
        onClockMission = 0;
        if (MinuteDegree == 2 && HourDegree == 5)
        {
            Clock1.SetActive(false);
            Clock2.SetActive(true);
        }
    }
    public void CheckMission()
    {

    }
}
