using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour // 카메라가 플레이어를 따라가게 하기 위한 코드 + 아이템 매니저 포함
{
    public GameObject Mcamera, mealart, Sun;
    GameObject Player, DManager,Mane, ManeApple, Devil;
    public Vector3 PlayerLocation;
    public static Vector3 Camlocation;

    public Item Phakpok, Pbiri, Pgija, Pgyotong, Pnodong, Key, Key2, Apple, SecretKey, Meal; // 획득 가능한 아이템들(인벤토리 관련)

    public Item PTusin, toxic, Pdnote, Snake, Idcard; //분노가 획득 가능한 아이템

    public Vector2 mouse, target;
    float angle;

    float devilscale;
    
    public struct Item //각 아이템의 오브젝트, 소유여부를 확인하기위한 구조체 선언
    {
        public GameObject Obj;
        public int Ininven; // 아이템을 획득하기 전이면 0, 획득하고 나서 1, 획득한 후 사용했다면 2로 설정.
    }
    Item[] Inventory; // 여러 아이템에 한번에 접근하기위한 배열 선언
    void Start()
    {
        

        Player = GameObject.Find("Player");
        Mcamera = GameObject.Find("Main Camera");
        DManager = GameObject.Find("DoorManager");

        //아이템 매니저와 병합
        Key.Obj = GameObject.Find("Key");
        Key2.Obj = GameObject.Find("Key2");
        SecretKey.Obj = GameObject.Find("SecretKey");

        Meal.Obj = GameObject.Find("meal");
        mealart = GameObject.Find("mealart");
        Apple.Obj = GameObject.Find("Apple");

        

        Phakpok.Obj = GameObject.Find("Phakpok");
        Pbiri.Obj = GameObject.Find("Pbiri");
        Pgija.Obj = GameObject.Find("Pgija");
        Pgyotong.Obj = GameObject.Find("Pgyotong");
        Pnodong.Obj = GameObject.Find("Pnodong");

        Mane = GameObject.Find("Mane");
        ManeApple = GameObject.Find("ManeApple");

        Devil = GameObject.Find("Devil");
        devilscale = 0.3f;

        target = transform.position;

        Sun = GameObject.Find("Sun");

        // 아래는 분노 오브젝트들 (인벤토리)

        PTusin.Obj = GameObject.Find("PTusin");
        toxic.Obj = GameObject.Find("toxic");
        Pdnote.Obj = GameObject.Find("Pdnote");
        Snake.Obj = GameObject.Find("Snake");
        Idcard.Obj = GameObject.Find("Idcard");


        
        ManeApple.SetActive(false);
        Sun.SetActive(false);
       
    }

    public void MakeInven()
    {
        if (MissionManager.Sin == 1)
        {
            Inventory = new Item[] { Key, Key2, SecretKey, Meal, Apple, Phakpok, Pnodong, Pgija, Pgyotong, Pbiri }; //획득 가능한 아이템을 구조체 배열로 지정해줌.
            for (int k = 0; k < Inventory.Length; k++)
            {
                Inventory[k].Obj.SetActive(false); // 시작 상태에선 아이템이 없으니 인벤토리에 표시하지 않음
                Inventory[k].Ininven = 0; // 초기 상태인 0, 없음으로 선언
            }
        }
        else if (MissionManager.Sin == 2)
        {
            Inventory = new Item[] { Key, Key2, SecretKey, Meal, Apple, PTusin, Pnodong, Pgija, Pgyotong, Pbiri }; //획득 가능한 아이템을 구조체 배열로 지정해줌.
            for (int k = 0; k < Inventory.Length; k++)
            {
                Inventory[k].Obj.SetActive(false); // 시작 상태에선 아이템이 없으니 인벤토리에 표시하지 않음
                Inventory[k].Ininven = 0; // 초기 상태인 0, 없음으로 선언
            }
        }
        else if (MissionManager.Sin == 3)
        {
            Inventory = new Item[] { Key, Key2, SecretKey, Meal, Apple, Phakpok, Pnodong, Pgija, Pgyotong, Pbiri }; //획득 가능한 아이템을 구조체 배열로 지정해줌.
            for (int k = 0; k < Inventory.Length; k++)
            {
                Inventory[k].Obj.SetActive(false); // 시작 상태에선 아이템이 없으니 인벤토리에 표시하지 않음
                Inventory[k].Ininven = 0; // 초기 상태인 0, 없음으로 선언
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLocation = new Vector3(Player.transform.position.x, Player.transform.position.y,Mcamera.transform.position.z) ;
        Mcamera.transform.position = (PlayerLocation);
        Camlocation = Mcamera.transform.position;
        

        //아이템 매니저와 병합

        for (int i = 0; i < Inventory.Length; i++) // 모든 인벤토리 내의 아이템들도 카메라를 따라오게함(화면 기준으로 고정)
        {
            Inventory[i].Obj.transform.position = SetPosition(PlayerLocation, i + 1);
        }
    }

    public Vector3 SetPosition(Vector3 Vec3, int order) // 카메라 좌표, 아이템 순서를 받아와서 그에 맞게 아이템 좌표(인벤토리칸) 업데이트
    {
        float orderY = 4.4f;
        if (order > 5)
        {
            orderY = 3.4f;
            order = order - 5;
        }
        Vector3 reVec3 = new Vector3(Vec3.x + 0.35f + 1.5f * order, Vec3.y + orderY, 1);
        return reVec3;
    }






    public void GetItem(int Itemcode) // 아이템을 획득하면 옵젝을 활성화하고 소유여부를 1로 조정한다
    {
        Inventory[Itemcode - 1].Obj.SetActive(true);
        Inventory[Itemcode - 1].Ininven = 1;
        Debug.Log(Itemcode);
        if (Itemcode < 4) // 1,2,3은 각 튜토리얼문, 수레 자물쇠, 시크릿룸 열쇠.
        {
            DManager.GetComponent<DoorManager>().ReadyOpen(Itemcode);
        }
        if (Itemcode == 4) // 4 벼 그림. 먹으면 맵의 태양 활성화
        {
           // Sun.SetActive(true);
        }
        else if (Itemcode == 5)
        {
            if (Inventory[4].Ininven == 1)
            {
                Mane.SetActive(true);
                Mane.GetComponent<ObjectData>().id++;
            }

        }
        
    }

    public void UseItem(int Itemcode) // 아이템을 사용했다는 의미로 구조체 Ininven 값을 2로 조정
    {
        Inventory[Itemcode - 1].Ininven = 2;
        if (Itemcode==5)
        {
            Mane.SetActive(false);
            ManeApple.SetActive(true);
            DManager.GetComponent<DoorManager>().Door123Open();
        }
    }


    public int CheckItem(int Itemcode) // 아이템이 있는지 확인하기위해 사용. 0=없음 1=있음 2=있었지만 사용함
    {
        Debug.Log(Inventory[Itemcode-1].Obj.name+" , "+Inventory[Itemcode-1].Ininven);
        return Inventory[Itemcode - 1].Ininven;
    }
    
    public void DevilScaleUp() // 악마 형상을 커지게 함
    {
        devilscale = devilscale + 0.1f;
        Devil.transform.localScale=new Vector3(devilscale, devilscale, 1);
        //Devil.GetComponent<ObjectData>().id=445;
    }
}
