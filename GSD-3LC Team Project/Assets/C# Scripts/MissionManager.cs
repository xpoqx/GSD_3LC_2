using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    GameObject Hour, Minute, Clock1, Clock2, Atlas, AtlasRock, Table, Doll, Cart, CartKey, Lock;
    public GameObject IHakpok,INodong,IGyotong; //미션 후 나타날 사진들
    public Vector3 Camloc; //카메라 위치
    public int onClockMission, HourDegree, MinuteDegree, onCartMission, onAtlasMission;
    GameObject target, CManager;
    Vector2 pos;
    RaycastHit2D hit;
    int clicktime = 0;

    // Start is called before the first frame update
    void Start()
    {
        CManager = GameObject.Find("CameraManager");

        Hour = GameObject.Find("Hour");
        Minute = GameObject.Find("Minute");
        Clock1 = GameObject.Find("Clock1");
        Clock2 = GameObject.Find("Clock2");
        Atlas= GameObject.Find("Atlas");
        AtlasRock= GameObject.Find("AtlasRock");
        Table = GameObject.Find("Table");
        Doll = GameObject.Find("Doll");
        Cart = GameObject.Find("Cart");
        CartKey = GameObject.Find("CartKey");
        Lock = GameObject.Find("Lock");
        //Hour.SetActive(false);
        //Minute.SetActive(false);
        Clock2.SetActive(false);
        ClockOff();
        CartOff();
        HourDegree = 2;
        MinuteDegree = 5;

        // 위쪽은 미션 오브젝트, 아래쪽은 미션을 통해 나타날 오브젝트.
        IHakpok = GameObject.Find("IHakpok");
        INodong = GameObject.Find("INodong");
        IGyotong = GameObject.Find("IGyotong");
        IHakpok.SetActive(false);
        INodong.SetActive(false);
        IGyotong.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Camloc = CameraManager.Camlocation;
        
        //2번방 시계미션 코드 시작
        if (onClockMission == 1)
        {
            
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
            
        // 2번방 시계미션 코드 끝

        // 4번방 수레미션 코드
        if (onCartMission == 1)
        {
            int havekey = CManager.GetComponent<CameraManager>().CheckItem(2);
            if (havekey == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                }
                if (hit.collider != null)
                {
                    target = hit.collider.gameObject;
                    if (target.Equals(Lock))
                    {
                        Lock.SetActive(false);
                        Table.GetComponent<ObjectData>().id = 402;
                        IGyotong.SetActive(true);
                        if (Cart.transform.position.x < Camloc.x+0.4f)
                        {
                            Cart.transform.Translate(0.005f, -0.00022f, 0);
                        }
                        else
                        {
                            if (Doll.transform.rotation.z > -0.75)
                            {
                                Doll.transform.Rotate(0, 0, -0.5f);
                                Debug.Log(Doll.transform.rotation);
                            }
                            if (Doll.transform.position.y > Camloc.y-0.2f)
                            {
                                Doll.transform.Translate(0.002f,0, 0);
                            }
                        }
                    }
                }
            }
            
            
        }
        else
        {
            
        }

       
        if (onAtlasMission == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                if (hit.collider != null)
                    target = hit.collider.gameObject;
                if (target.Equals(AtlasRock))
                    clicktime += 1; //아틀라스락 클릭하면 횟수증가
            }
            if (clicktime >= 5) //5번 클릭시 아클라스락 추락
            {
                if (AtlasRock.transform.position.y > Camloc.y - 1.12f)
                {
                    AtlasRock.GetComponent<BoxCollider2D>().enabled = false; // 바위 콜라이더 비활성화
                    AtlasRock.transform.Translate(0, -0.05f, 0);
                }

            }
            
        }
        else
        {

        }




        // 5번방 아틀라스미션 코드 


    }

    public void ClockOn()
    {
        //Hour.SetActive(true);
        //Minute.SetActive(true);
        onClockMission = 1;
        Hour.transform.position = new Vector3(Camloc.x + 0.1f, Camloc.y + 1.25f, 1);
        Minute.transform.position = new Vector3(Camloc.x + 0.1f, Camloc.y + 1.25f, 1);
        Hour.transform.localScale = new Vector3(0.4f, 0.4f, 1);
        Minute.transform.localScale = new Vector3(0.4f, 0.4f, 1);
    }
    public void ClockOff()
    {
        //Hour.SetActive(false);
        //Minute.SetActive(false);
        onClockMission = 0;
        if (MinuteDegree == 2 && HourDegree == 5)
        {
            Clock1.SetActive(false);
            Clock2.SetActive(true);
            IHakpok.SetActive(true);
        }
        Hour.transform.position = new Vector3(56.02f, 20.92f, 1);
        Minute.transform.position = new Vector3(56.02f, 20.92f, 1);
        Hour.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        Minute.transform.localScale = new Vector3(0.1f, 0.1f, 1);
    }

    public void CartOn()
    {
        onCartMission = 1;
        int complete=Table.GetComponent<ObjectData>().id;
        if (complete == 401)
        {
            Cart.transform.position = new Vector3(Camloc.x - 1.35f, Camloc.y + 0.15f, 1);
            Doll.transform.position = new Vector3(Camloc.x + 1.35f, Camloc.y + 0.06f, 1);
            Lock.transform.position = new Vector3(Camloc.x - 2.21f, Camloc.y + 0.12f, 1);
            Cart.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            Doll.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            Lock.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
        else
        {
            Cart.transform.position = new Vector3(Camloc.x + 0.4f, Camloc.y +0.1f, 1);
            Doll.transform.position = new Vector3(Camloc.x + 1.7f, Camloc.y - 0.2f, 1);
            Cart.transform.localScale = new Vector3(0.5f, 0.5f, 1); 
            Doll.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
        
        
    } 
    public void CartOff()
    {
        onCartMission = 0;
        int complete = Table.GetComponent<ObjectData>().id;
        if (complete == 401)
        {
            Cart.transform.position = new Vector3(39.455f, -9.069f, 1);
            Doll.transform.position = new Vector3(40.522f, -9.109f, 1);
            Lock.transform.position = new Vector3(39.114f, -9.088f, 1);
            Cart.transform.localScale = new Vector3(0.2f, 0.2f, 1);
            Doll.transform.localScale = new Vector3(0.2f, 0.2f, 1);
            Lock.transform.localScale = new Vector3(0.2f, 0.2f, 1);
        }
        else
        {
            Cart.transform.position = new Vector3(40.086f, -9.078f, 1);
            Doll.transform.position = new Vector3(40.558f, -9.171f, 1);
            Cart.transform.localScale = new Vector3(0.2f, 0.2f, 1);
            Doll.transform.localScale = new Vector3(0.2f, 0.2f, 1);
        }
    }

    public void AtlasOn()
    {
        onAtlasMission = 1;
        if(clicktime>=5)
        {
            AtlasRock.transform.position = new Vector3(Camloc.x, Camloc.y -1.12f, 1);
            AtlasRock.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            AtlasRock.transform.position = new Vector3(Camloc.x, Camloc.y + 2.6f, 1);
            AtlasRock.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void AtlasOff()
    {
        onAtlasMission = 0;
        if (clicktime >= 5)
        {
            AtlasRock.transform.position = new Vector3(55.88f, -15.64f, 1);
            AtlasRock.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }
        else
        {
            AtlasRock.transform.position = new Vector3(55.88f, -14.64f, 1);
            AtlasRock.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }
    }
    public void CheckMission()
    {

    }
}
