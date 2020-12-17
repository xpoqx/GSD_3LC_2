using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class MissionManager : MonoBehaviour
{
    public int SelectSin;


    GameObject Player, PManager;

    GameObject Hour, Minute, Clock1, Clock2, Atlas, AtlasRock, Table, Doll, Cart, CartKey, Lock,
        Chesspawn, Chessking, Chess, Drawer, TutWall, PushWall, Npc1, Npc2, Npc3;
    public GameObject IHakpok, INodong, IGyotong, IBiri, IGija; //미션 후 나타날 사진들
    public Vector3 Camloc; //카메라 위치
    public int onClockMission, HourDegree, MinuteDegree, onCartMission, onAtlasMission,
        onChessMission, onDrawerMission, onIraMisson1, onIraMisson2, onIraMission4, onIraMission5, onUniMission;
    GameObject target, CManager, GManager;
    Vector2 pos;
    RaycastHit2D hit;
    float chessx, chessy, chessx1, chessy1, knifex, knifey;
    int clicktime, WaterClick, SandClick;
    bool DeletedNpc, Ira1Knifed, ClearedSun, Clicked, Exploded;

    /// <summary>
    /// ////////////////////////
    /// </summary>

    GameObject PuzzleMain, KnifeDoll, Knife, ITusin, IToxic, Ira1Mission, PFlashL, PDnote, SunnySun, Sunny,
        Moonny, Toxic, WaterCup, SandCup, WaterObject, SandWater, Snake, Luxuria, Smoke, Lighter, PLighter
        , Fireplace, IDcard;      //분노 옵젝

    GameObject EnterKnife;
    InputField EKtext;

    public GameObject Mane, ManeApple, Bcard, Glass, GlassObj, Mentle, Volcano, Mentle2, Bag, Horse, UnicornObj, Puni
        , Hill;            //음욕 옵젝
    int onLuxMission3, onVolcanoMission, ClickedMentle,ClearedUni;

    public static int Sin;

    

    // Start is called before the first frame update
    void Start()
    {
        //Sin = 0;    
        Sin = SelectSin;// 죄종 사전설정 1교만2분노3음욕

        Luxuria = GameObject.Find("Luxuria");

        clicktime = 0;
        Player = GameObject.Find("Player");
        DeletedNpc = false;

        CManager = GameObject.Find("CameraManager");
        GManager = GameObject.Find("GameManager");
        PManager = GameObject.Find("PlayerController");

        Hour = GameObject.Find("Hour");
        Minute = GameObject.Find("Minute");
        Clock1 = GameObject.Find("Clock1");
        Clock2 = GameObject.Find("Clock2");
        Atlas = GameObject.Find("Atlas");
        AtlasRock = GameObject.Find("AtlasRock");
        Table = GameObject.Find("Table");
        Doll = GameObject.Find("Doll");
        Cart = GameObject.Find("Cart");
        CartKey = GameObject.Find("CartKey");
        Lock = GameObject.Find("Lock");
        Chesspawn = GameObject.Find("Chesspawn");
        Chessking = GameObject.Find("Chessking");
        Chess = GameObject.Find("Chess");
        Drawer = GameObject.Find("서랍01");
        TutWall = GameObject.Find("튜토리얼 위벽");
        PushWall = GameObject.Find("PushWall");
        Npc1 = GameObject.FindWithTag("Sin1Npc");
        Npc2 = GameObject.FindWithTag("Sin2Npc");
        Npc3 = GameObject.FindWithTag("Sin3Npc");


        Clock2.SetActive(false);
        ClockOff();
        CartOff();
        ChessOff();
        AtlasOff();
        HourDegree = 2;
        MinuteDegree = 5;

        // 위쪽은 미션 오브젝트, 아래쪽은 미션을 통해 나타날 오브젝트.
        IHakpok = GameObject.Find("IHakpok");
        INodong = GameObject.Find("INodong");
        IGyotong = GameObject.Find("IGyotong");
        IBiri = GameObject.Find("IBiri");
        IGija = GameObject.Find("IGija");
        IHakpok.SetActive(false);
        INodong.SetActive(false);
        IGyotong.SetActive(false);
        IBiri.SetActive(false);
        IGija.SetActive(false);

        chessx = -0.25f;
        chessy = 1.1f;
        chessx1 = 0.132f;
        chessy1 = -0.135f;

        //분노 오브젝트
        PuzzleMain = GameObject.Find("PuzzleMain");
        EnterKnife = GameObject.Find("EnterKnife");
        EKtext = EnterKnife.GetComponent<InputField>();
        ITusin = GameObject.Find("ITusin");
        Ira1Mission = GameObject.Find("Ira1Mission");
        PFlashL = GameObject.Find("PFlashL");
        PDnote = GameObject.Find("PDnote");
        SunnySun = GameObject.Find("SunnySun");
        Sunny = GameObject.Find("Sunny");
        Moonny = GameObject.Find("Moonny");
        Toxic = GameObject.Find("Toxic");
        WaterCup = GameObject.Find("WaterCup");
        SandCup = GameObject.Find("SandCup");
        WaterObject = GameObject.Find("WaterObject");
        SandWater = GameObject.Find("흙탕물");
        Snake = GameObject.Find("Snake");
        Smoke = GameObject.Find("Smoke");
        Lighter = GameObject.Find("Lighter");
        PLighter = GameObject.Find("PLighter");
        Fireplace = GameObject.Find("Fireplace");
        IDcard = GameObject.Find("IDcard");




        WaterClick = 1;
        SandClick = 1;

        IDcard.SetActive(false);
        Smoke.SetActive(false);
        Snake.SetActive(false);
        SandWater.SetActive(false);
        Toxic.SetActive(false);
        Moonny.SetActive(false);
        PDnote.SetActive(false);
        SunnySun.SetActive(false);
        PFlashL.SetActive(false);

        Ira1Knifed = false;
        ClearedSun = false;


        PuzzleMainOff();
        ITusin.SetActive(false);
        KnifeDoll = GameObject.Find("KnifeDoll");
        Knife = GameObject.Find("Knife");
        PFlashL.SetActive(false);
        KnifeDoll.SetActive(false);


        Ira4Off();
        Ira5Off();

        //음욕 코드 시작

        Mane = GameObject.Find("Mane");
        ManeApple = GameObject.Find("ManeApple");
        Bcard = GameObject.Find("Bcard");
        Glass = GameObject.Find("Glass");
        GlassObj = GameObject.Find("GlassObj");
        Mentle = GameObject.Find("Mentle1");
        Mentle2 = GameObject.Find("Mentle2");
        Volcano = GameObject.Find("Volcano");
        Bag = GameObject.Find("Bag");
        Horse = GameObject.Find("Horse");
        UnicornObj = GameObject.Find("UnicornObj");
        Puni = GameObject.Find("Puni");
        Hill = GameObject.Find("Hill");

        Hill.SetActive(false);
        ClickedMentle = 0;
        Bag.SetActive(false);
        Exploded = false;
        VolcanoOff();
        Bcard.SetActive(false);
        ClearedUni = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Sin != 0 && !DeletedNpc) // 죄가 선택되면 해당하는 NPC 삭제.
        {
            CManager.GetComponent<CameraManager>().MakeInven(); //죄종에 맞는 인벤토리 생성.
            if (Sin == 1)
            {
                Npc1.SetActive(false);
            }
            else
            {
                //Drawer.GetComponent<ObjectData>().id = 2;
                Drawer.GetComponent<ObjectData>().isItem = false;
            }
            if (Sin == 2)
            {
                Npc2.SetActive(false);
            }
            else
            {

            }
            if (Sin == 3)
            {
                Npc3.SetActive(false);
                Mane.GetComponent<ObjectData>().SinNumber = 3;
                ManeApple.GetComponent<ObjectData>().SinNumber = 3;
            }
            else
            {

            }
            DeletedNpc = true;
        }

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
                        if (CManager.GetComponent<CameraManager>().CheckItem(9) == 0)
                        {
                            IGyotong.SetActive(true);
                            IGyotong.transform.position = new Vector2(42, -9);
                        }

                        if (Cart.transform.position.x < Camloc.x + 0.4f)
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
                            if (Doll.transform.position.y > Camloc.y - 0.2f)
                            {
                                Doll.transform.Translate(0.002f, 0, 0);
                            }
                        }
                    }
                }
            }


        }
        else
        {

        }

        //5번방 아틀라스 바위 미션 코드 시작
        if (onAtlasMission == 1)
        {

            if (Input.GetMouseButtonDown(0))
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                if (hit.collider != null)
                {
                    target = hit.collider.gameObject;
                    if (target.Equals(AtlasRock))
                        clicktime += 1; //아틀라스락 클릭하면 횟수증가
                }
            }
            if (clicktime >= 5) //5번 클릭시 아클라스락 추락
            {
                AtlasRock.GetComponent<BoxCollider2D>().enabled = false; // 바위 콜라이더 비활성화
                if (CManager.GetComponent<CameraManager>().CheckItem(8) == 0)
                {
                    Atlas.GetComponent<ObjectData>().id = 502;
                    IGija.SetActive(true);
                    IGija.transform.position = new Vector2(57.43f, -15.42f);
                }
                if (AtlasRock.transform.position.y > Camloc.y - 1.12f)
                {

                    AtlasRock.transform.Translate(0, -0.05f, 0);
                }

            }

        }
        else
        {

        }
        // 5번방 아틀라스미션 코드 끝

        // 6번방 체스 미션 코드 시작
        if (onChessMission == 1)
        {
            chessx = Chessking.transform.position.x - Camloc.x;
            chessy = Chessking.transform.position.y - Camloc.y;
            chessx1 = Chesspawn.transform.position.x - Camloc.x;
            chessy1 = Chesspawn.transform.position.y - Camloc.y;
        }





        if (onIraMisson1 == 1)
        {
            knifex = Camloc.x - Knife.transform.position.x;
            knifey = Camloc.y - Knife.transform.position.y;
            if (knifex > -0.2f && knifex < 0.4f)
            {
                if (knifey > -1.4f && knifey < -0.7f)
                {
                    Knife.transform.position = new Vector2(Camloc.x - 0.25f, Camloc.y + 1.17f);
                    Knife.transform.localScale = new Vector2(0.16f, -0.16f);


                }
            }
            int havekey = CManager.GetComponent<CameraManager>().CheckItem(3);
            if (havekey == 1)
            {
                int a = 0;
                if (Input.GetMouseButtonDown(0))
                {
                    pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                    a = 1;
                }
                if (hit.collider != null && a == 1)
                {
                    target = hit.collider.gameObject;
                    if (target.GetComponent<ObjectData>().id == 3)
                    {
                        PFlashL.SetActive(true);
                        PFlashL.transform.position = new Vector2(Camloc.x, Camloc.y - 4);
                        CManager.GetComponent<CameraManager>().UseItem(3);
                    }

                }

            }
            if (PFlashL.transform.position.y > Camloc.y - 2)
            {
                if (CManager.GetComponent<CameraManager>().CheckItem(4) == 0)
                    PDnote.SetActive(true);
            }

        }


        if (onIraMisson2 == 1)
        {
            float Range = Camloc.x - SunnySun.transform.position.x;
            float Rangey = Camloc.y - SunnySun.transform.position.y;
            if (Range > 4 || Range < -4)
            {
                if (!ClearedSun)
                {
                    SunnySun.SetActive(false);
                    ClearedSun = true;
                    GManager.GetComponent<GameManager>().Action(Sunny);
                    Sunny.SetActive(false);
                    Moonny.SetActive(true);
                    Toxic.SetActive(true);
                    GManager.GetComponent<GameManager>().Action(Moonny);
                    Moonny.GetComponent<ObjectData>().id = 2203;
                }
            }
        }
        if (Sin == 2)
        {
            if (onIraMission4 == 1)
            {

                if (Input.GetMouseButtonDown(0))
                {



                    pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                    if (hit.collider != null)
                    {
                        target = hit.collider.gameObject;
                        if (target.Equals(WaterCup))
                        {
                            if (WaterClick < 11)
                            {
                                WaterClick++;
                            }
                        }
                        else if (target.Equals(SandCup) || target.Equals(WaterObject))
                        {
                            if (SandClick < 4)
                            {
                                SandClick++;
                            }
                        }
                    }
                }
                LoadImage(WaterCup, WaterClick);
                LoadImage(SandCup, SandClick);
                if (WaterClick == 11 && SandClick == 4 && !Clicked)
                {
                    GManager.GetComponent<GameManager>().Action(WaterObject);
                    WaterObject.GetComponent<ObjectData>().id = 2402;
                    GManager.GetComponent<GameManager>().Action(WaterObject);
                    SandWater.SetActive(true);
                    Snake.SetActive(true);
                    Clicked = true;
                }
            }


            if (onIraMission5 == 1)
            {

            }
            else
            {
                int have = CManager.GetComponent<CameraManager>().CheckItem(11);
                if (have == 1)
                {
                    Fireplace.GetComponent<ObjectData>().id = 2506;
                }
                else if (have == 2)
                {
                    int have2 = CManager.GetComponent<CameraManager>().CheckItem(6);
                    if (have2 == 1)
                    {
                        Fireplace.GetComponent<ObjectData>().id = 2508;
                    }
                }
            }
        }

        if (Sin == 3)
        {
            if (onLuxMission3 == 1)
            {

            }
            else
            {
                int have = CManager.GetComponent<CameraManager>().CheckItem(2);
                if (have == 1)
                {
                    GlassObj.GetComponent<ObjectData>().id = 4306;


                }
            }

            if (onVolcanoMission == 1)
            {
                if (Input.GetMouseButtonDown(0) && !Exploded)
                {
                    pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                    if (hit.collider != null)
                    {
                        target = hit.collider.gameObject;
                        if (target.Equals(Mentle) && ClickedMentle < 4)
                        {
                            Mentle.transform.Translate(0.2f, 0, 0);
                            ClickedMentle++;
                            if (ClickedMentle == 4)
                            {
                                Exploded = true;
                            }
                        }
                    }
                }
            }

            else
            {

            }
            if (onUniMission == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                    if (hit.collider != null)
                    {
                        target = hit.collider.gameObject;
                        if (target.Equals(UnicornObj))
                        {
                            UnicornObj.SetActive(false);
                            Horse.GetComponent<ObjectData>().isItem = true;
                            GManager.GetComponent<GameManager>().Action(Horse);
                            Horse.GetComponent<ObjectData>().id = 4102;
                            GManager.GetComponent<GameManager>().Action(Horse);
                            Horse.SetActive(true);
                            Horse.GetComponent<ObjectData>().isItem = false;
                            Horse.GetComponent<ObjectData>().id = 4101;

                        }
                        else if (target.Equals(Puni) && ClearedUni == 0)
                        {
                            GManager.GetComponent<GameManager>().Action(Horse);
                            Horse.GetComponent<ObjectData>().id = 4103;
                            GManager.GetComponent<GameManager>().Action(Horse);
                            ClearedUni = 1;

                        }
                    }
                }
            }
            else
            {

            }
        }



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
        Hour.GetComponent<SpriteRenderer>().sortingOrder = 8;
        Minute.GetComponent<SpriteRenderer>().sortingOrder = 8;
    }
    public void ClockOff()
    {
        onClockMission = 0;
        if (Sin == 1)
        {
            
            if (MinuteDegree == 2 && HourDegree == 5)
            {
                Clock1.SetActive(false);
                Clock2.SetActive(true);
                IHakpok.SetActive(true);
            }
        }
        Hour.transform.position = new Vector3(56.02f, 20.92f, 1);
        Minute.transform.position = new Vector3(56.02f, 20.92f, 1);
        Hour.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        Minute.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        Hour.GetComponent<SpriteRenderer>().sortingOrder = 2;
        Minute.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    public void CartOn()
    {
        onCartMission = 1;
        int complete = Table.GetComponent<ObjectData>().id;
        if (complete == 401)
        {
            Cart.transform.position = new Vector3(Camloc.x - 1.35f, Camloc.y + 0.15f, 1);
            Doll.transform.position = new Vector3(Camloc.x + 1.35f, Camloc.y + 0.06f, 1);
            Lock.transform.position = new Vector3(Camloc.x - 2.21f, Camloc.y + 0.12f, 1);
            Cart.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            Doll.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            Lock.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            Cart.GetComponent<SpriteRenderer>().sortingOrder = 8;
            Doll.GetComponent<SpriteRenderer>().sortingOrder = 8;
            Lock.GetComponent<SpriteRenderer>().sortingOrder = 8;
        }
        else
        {
            Cart.transform.position = new Vector3(Camloc.x + 0.4f, Camloc.y + 0.1f, 1);
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
            Cart.GetComponent<SpriteRenderer>().sortingOrder = 2;
            Doll.GetComponent<SpriteRenderer>().sortingOrder = 2;
            Lock.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else
        {
            Cart.transform.position = new Vector3(40.086f, -9.078f, 1);
            Doll.transform.position = new Vector3(40.558f, -9.171f, 1);
            Cart.transform.localScale = new Vector3(0.2f, 0.2f, 1);
            Doll.transform.localScale = new Vector3(0.2f, 0.2f, 1);
            Cart.GetComponent<SpriteRenderer>().sortingOrder = 2;
            Doll.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }

    public void AtlasOn()
    {
        AtlasRock.GetComponent<SpriteRenderer>().sortingOrder = 8;
        onAtlasMission = 1;
        if (clicktime >= 5)
        {
            AtlasRock.transform.position = new Vector3(Camloc.x, Camloc.y - 1.12f, 1);
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
        AtlasRock.GetComponent<SpriteRenderer>().sortingOrder = 2;
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

    public void ChessOn()
    {
        onChessMission = 1;
        Chessking.SetActive(true);
        Chesspawn.SetActive(true);
        Chessking.transform.position = new Vector2(Camloc.x + chessx, Camloc.y + chessy);
        Chesspawn.transform.position = new Vector2(Camloc.x + chessx1, Camloc.y + chessy1);
        Player.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void ChessOff()
    {
        onChessMission = 0;
        Debug.Log(chessy1 + "," + chessy);
        if (chessy < 0 && chessy1 > 1)
        {
            Chesspawn.GetComponent<BoxCollider2D>().enabled = false;
            Chessking.GetComponent<BoxCollider2D>().enabled = false;
            Chess.GetComponent<ObjectData>().id = 602;
            if (CManager.GetComponent<CameraManager>().CheckItem(10) == 0)
            {
                IBiri.SetActive(true);
                IBiri.transform.position = new Vector2(72.81f, -7.42f);
            }

        }
        Chessking.SetActive(false);
        Chesspawn.SetActive(false);
        Chessking.transform.position = new Vector2(Camloc.x + chessx, Camloc.y + chessy);
        Chesspawn.transform.position = new Vector2(Camloc.x + chessx1, Camloc.y + chessy1);
        Player.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void WallOn()
    {
        if (PushWall.GetComponent<ObjectData>().id == 6)
        {
            TutWall.transform.Translate(-8.5f, 0, 0);
            PushWall.SetActive(false);
        }
        PushWall.GetComponent<ObjectData>().id = 6;
        
    }

    public void DrawerOn()
    {
        if (Sin == 0 && Sin==1)
        {
            Drawer.GetComponent<ObjectData>().id = 4;
            Drawer.GetComponent<ObjectData>().isItem = false;
            Sin = 1;
        }
        else
        {

        }
    }

    //분노 관련

    public void PuzzleMainOn()
    {
        PuzzleMain.transform.position = new Vector3(Camloc.x, Camloc.y + 1.2f, 1);
        PuzzleMain.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        PuzzleMain.SetActive(true);
        if (Sin == 2)
        {
            EnterKnife.SetActive(true);
        }
    }
    public void PuzzleMainOff()
    {
        //Debug.Log(EKtext.text);
        if (Sin == 2)
        {
            ITusin.SetActive(true);
        }
        PuzzleMain.transform.position = new Vector3(20, 7, 1);
        PuzzleMain.transform.localScale = new Vector3(0.2f, 0.2f, 1);
        PuzzleMain.SetActive(false);
        EnterKnife.SetActive(false);
    }


    public void Ira1On()
    {
        if (knifex > -0.2f && knifex < 0.4f)
        {
            if (knifey > -1.4f && knifey < -0.7f)
            {
                Knife.transform.position = new Vector2(Camloc.x - 0.25f, Camloc.y + 1.17f);
                Knife.transform.localScale = new Vector2(0.16f, -0.16f);

            }
            else
            {
                Knife.transform.position = new Vector3(Camloc.x + 0.54f, Camloc.y + 1.88f, 1);
                Knife.transform.localScale = new Vector3(0.16f, 0.16f, 1);
            }
        }
        else
        {
            Knife.transform.position = new Vector3(Camloc.x + 0.54f, Camloc.y + 1.88f, 1);
            Knife.transform.localScale = new Vector3(0.16f, 0.16f, 1);
        }
        onIraMisson1 = 1;
        KnifeDoll.transform.position = new Vector3(Camloc.x, Camloc.y + 1.2f, 1);
        KnifeDoll.transform.localScale = new Vector3(0.8f, 0.8f, 1);

        KnifeDoll.SetActive(true);
    }
    public void Ira1Off()
    {
        if (knifex > -0.2f && knifex < 0.4f)
        {
            if (knifey > -1.4f && knifey < -0.7f)
            {
                if (CManager.GetComponent<CameraManager>().CheckItem(9) == 0&&Sin==2)
                {
                    IGyotong.SetActive(true);
                    IGyotong.transform.position = new Vector2(34, 12);
                }
                Knife.transform.position = new Vector3(32.01f, 12.49f, 1);
                Knife.transform.localScale = new Vector3(0.04f, -0.04f, 1);
                if (!Ira1Knifed)
                {
                    Ira1Mission.GetComponent<ObjectData>().id = 2102;
                    Ira1Knifed = true;
                }
            }
            else
            {
                Knife.transform.position = new Vector3(32.22f, 12.68f, 1);
                Knife.transform.localScale = new Vector3(0.04f, 0.04f, 1);
            }
        }
        else
        {
            Knife.transform.position = new Vector3(32.22f, 12.68f, 1);
            Knife.transform.localScale = new Vector3(0.04f, 0.04f, 1);
        }
        onIraMisson1 = 0;
        KnifeDoll.transform.position = new Vector3(32.08f, 12.51f, 1);
        KnifeDoll.transform.localScale = new Vector3(0.2f, 0.2f, 1);
        PFlashL.SetActive(false);
        KnifeDoll.SetActive(false);
        if (CManager.GetComponent<CameraManager>().CheckItem(3) == 2)
        {
            CManager.GetComponent<CameraManager>().ReloadItem(3);
            target = null;
        }
    }

    public void Ira2On()
    {

        if (!ClearedSun)
        {
            SunnySun.SetActive(true);
        }
        SunnySun.transform.position = new Vector3(Camloc.x - 1.5f, Camloc.y + 3.0f, 1);
        onIraMisson2 = 1;
    }
    public void Ira2Off()
    {
        onIraMisson2 = 0;
        SunnySun.SetActive(false);
    }

    public void GetTusin()
    {
        Luxuria.SetActive(true);
        Luxuria.transform.position = CameraManager.Camlocation;
        GManager.GetComponent<GameManager>().Action(Luxuria);

    }

    public void Ira3On()
    {

    }
    public void Ira3Off()
    {

    }


    public void Ira4On()
    {
        onIraMission4 = 1;
        WaterCup.transform.position = new Vector2(Camloc.x - 1.6f, Camloc.y);
        SandCup.transform.position = new Vector2(Camloc.x + 1.3f, Camloc.y);
        WaterCup.transform.localScale = new Vector2(0.3f, 0.3f);
        SandCup.transform.localScale = new Vector2(0.3f, 0.3f);
        WaterCup.GetComponent<SpriteRenderer>().sortingOrder = 8;
        SandCup.GetComponent<SpriteRenderer>().sortingOrder = 8;
    }
    public void Ira4Off()
    {
        onIraMission4 = 0;
        WaterCup.transform.position = new Vector2(45.39f, -5.51f);
        SandCup.transform.position = new Vector2(45.876f, -5.512f);
        WaterCup.transform.localScale = new Vector2(0.05f, 0.05f);
        SandCup.transform.localScale = new Vector2(0.05f, 0.05f);
        WaterCup.GetComponent<SpriteRenderer>().sortingOrder = 2;
        SandCup.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    void LoadImage(GameObject img, int num)
    {
        if (num == 1)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image1;
        }
        else if (num == 2)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image2;
        }
        else if (num == 3)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image3;
        }
        else if (num == 4)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image4;
        }
        else if (num == 5)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image5;
        }
        else if (num == 6)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image6;
        }
        else if (num == 7)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image7;
        }
        else if (num == 8)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image8;
        }
        else if (num == 9)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image9;
        }
        else if (num == 10)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image10;
        }
        else if (num == 11)
        {
            img.GetComponent<SpriteRenderer>().sprite = img.GetComponent<Images>().Image11;
        }
    }

    public void Ira5On()
    {
        onIraMission5 = 1;
        int have = CManager.GetComponent<CameraManager>().CheckItem(11);
        if (have == 1)
        {
            Smoke.SetActive(true);
            Smoke.GetComponent<SpriteRenderer>().sprite = Smoke.GetComponent<Images>().Image2;
            CManager.GetComponent<CameraManager>().UseItem(11);
            Fireplace.GetComponent<ObjectData>().id = 2507;
            IBiri.SetActive(true);
            IBiri.transform.position = new Vector2(58.03f, -11.86f);
        }
        else if (have == 2)
        {
            int have2 = CManager.GetComponent<CameraManager>().CheckItem(6);
            if (have2 == 1)
            {
                Smoke.GetComponent<SpriteRenderer>().sprite = Smoke.GetComponent<Images>().Image1;
                IGija.SetActive(true);
                IGija.transform.position = new Vector2(57.43f, -15.42f);
                CManager.GetComponent<CameraManager>().UseItem(6);
                Fireplace.GetComponent<ObjectData>().id = 2509;
            }
        }
        Smoke.transform.position = new Vector2(Camloc.x, Camloc.y + 0.95f);
        Smoke.transform.localScale = new Vector2(0.16f, 0.16f);
        Smoke.GetComponent<SpriteRenderer>().sortingOrder = 8;
    }
    public void Ira5Off()
    {
        onIraMission5 = 0;
        Smoke.transform.position = new Vector2(56, -11.63f);
        Smoke.transform.localScale = new Vector2(0.1f, 0.1f);
        Smoke.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
    public void ShowIDcard()
    {
        IDcard.SetActive(true);
    }

    public void Appled()
    {
        Bcard.SetActive(true);
    }

    public void Lux3On()
    {
        onLuxMission3 = 1;
        if (CManager.GetComponent<CameraManager>().CheckItem(2) == 1)
        {
            LoadImage(Glass, 2);
            CManager.GetComponent<CameraManager>().UseItem(2);

        }
        if (GlassObj.GetComponent<ObjectData>().id < 4307)
        {
            Glass.transform.position = new Vector2(Camloc.x, Camloc.y + 1.2f);
            Glass.GetComponent<SpriteRenderer>().sortingOrder = 8;
            Glass.transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }
    public void Lux30Off()
    {
        onLuxMission3 = 0;
        Glass.GetComponent<SpriteRenderer>().sortingOrder = 2;
        Glass.transform.position = new Vector2(71.43f, 12.53f);
        Glass.transform.localScale = new Vector2(0.15f, 0.15f);


        if (GlassObj.GetComponent<ObjectData>().id == 4307)
        {
            GlassObj.SetActive(false);
            Glass.SetActive(false);

        }
        if (CManager.GetComponent<CameraManager>().CheckItem(2) == 2)
        {
            GlassObj.GetComponent<ObjectData>().id = 4307;
            LoadImage(Glass, 3);
            GlassObj.GetComponent<ObjectData>().isItem = true;
            Glass.transform.localScale = new Vector2(0.1f, 0.1f);
        }
    }
    public void VolcanoOn()
    {
        onVolcanoMission = 1;
        if (Exploded)
        {
            Mentle.transform.position = new Vector2(Camloc.x - 1.6f, Camloc.y - 0.4f);
            Mentle.transform.localScale = new Vector2(0.4f, 0.2f);
        }
        else
        {
            Mentle.transform.position = new Vector2(Camloc.x - 2f, Camloc.y - 0.4f);
            Mentle.transform.localScale = new Vector2(0.28f, 0.2f);

        }
        Mentle2.transform.position = new Vector2(Camloc.x + 1.6f, Camloc.y - 0.4f);


        Mentle2.transform.localScale = new Vector2(0.55f, 0.2f);
        Mentle.GetComponent<SpriteRenderer>().sortingOrder = 8;
        Mentle2.GetComponent<SpriteRenderer>().sortingOrder = 8;
    }
    public void VolcanoOff()
    {
        if (Exploded)
        {
            Mentle.transform.position = new Vector2(61.76f, -20f);
            LoadImage(Volcano, 2);
            Volcano.GetComponent<ObjectData>().id = 4502;
        }
        else
        {
            Mentle.transform.position = new Vector2(61.42f, -20f);
        }
        onVolcanoMission = 0;

        Mentle2.transform.position = new Vector2(63.18f, -20f);

        Mentle.transform.localScale = new Vector2(0.12f, 0.1f);
        Mentle2.transform.localScale = new Vector2(0.3f, 0.1f);
        Mentle.GetComponent<SpriteRenderer>().sortingOrder = 2;
        Mentle2.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    public void GiveItem(int code) // 아이템을 주는 NPC에게 말을 걸었을떄 아이템 드랍용
    {
        int have = CManager.GetComponent<CameraManager>().CheckItem(code);
        if (have == 0)
        {
            if (code == 1)
            {
                Bag.SetActive(true);
            }
            else if (code == 7)
            {
                Hill.SetActive(true);
            }
            else if (code == 10)
            {
                IBiri.SetActive(true);
                IBiri.transform.position = new Vector2(17.09f, -3.15f);
            }
        }
    }

    public void UniOn()
    {
        onUniMission = 1;
        UnicornObj.transform.localScale = new Vector2(1, 1);
        UnicornObj.transform.position = new Vector2(Camloc.x + 3.4f, Camloc.y - 0.4f);
    }
    public void UniOff()
    {
        onUniMission = 0;
        UnicornObj.transform.localScale = new Vector2(0.1f, 0.1f);
        UnicornObj.transform.position = new Vector2(41.67f, 13.69f);
    }
}
