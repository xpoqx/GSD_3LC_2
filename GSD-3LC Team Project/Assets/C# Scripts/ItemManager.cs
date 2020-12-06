using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    Item Phakpok, Pbiri, Pgija, Pgyotong, Pnodong, Key, Apple;
    Vector3 CamPosition;
    GameObject InventoryUI;
    public struct Item //각 아이템의 오브젝트, 소유여부를 확인하기위한 구조체 선언
    {
        public GameObject Obj;
        public int Ininven; // 아이템을 획득하기 전이면 0, 획득하고 나서 1, 획득한 후 사용했다면 2로 설정.
    }
    Item[] Inventory; // 여러 아이템에 한번에 접근하기위한 배열 선언
    
    void Start()
    {

        InventoryUI = GameObject.Find("InventoryUI"); //인벤토리, 획득가능한 아이템들 Find.
        Phakpok.Obj = GameObject.Find("Phakpok");
        Pbiri.Obj = GameObject.Find("Pbiri");
        Pgija.Obj = GameObject.Find("Pgija");
        Pgyotong.Obj = GameObject.Find("Pgyotong");
        Pnodong.Obj = GameObject.Find("Pnodong");
        Key.Obj = GameObject.Find("Key");
        Apple.Obj = GameObject.Find("Apple");

        Inventory = new Item[] { Phakpok, Pbiri, Pgija, Pgyotong, Pnodong, Key, Apple }; //획득 가능한 아이템을 구조체 배열로 지정해줌.
        for (int k = 0; k < Inventory.Length; k++)
        {
            SetFalse(Inventory[k].Obj); // 시작 상태에선 아이템이 없으니 인벤토리에 표시하지 않음
            Inventory[k].Ininven = 0; // 초기 상태인 0, 없음으로 선언
        }
    }

    // Update is called once per frame
    void Update()
    {
        //UI로 수정시도 주석처리
        //InventoryUI.transform.position = new Vector3(CamPosition.x + 4.875f, CamPosition.y + 3.9f, 1); // 카메라(화면)를 따라가는 인벤토리 좌표
        CamPosition = CameraManager.Camlocation; // 전역변수로 선언한 카메라 좌표 by CameraManager
        for (int i = 0; i < Inventory.Length; i++) // 모든 인벤토리 내의 아이템들도 카메라를 따라오게함(화면 기준으로 고정)
        {
            Inventory[i].Obj.transform.position = SetPosition(CamPosition, i+1);
        }
        
        
    }
    

    public Vector3 SetPosition (Vector3 Vec3, int order) // 카메라 좌표, 아이템 순서를 받아와서 그에 맞게 아이템 좌표(인벤토리칸) 업데이트
    {
        float orderY = 4.4f;
        if (order > 5)
        {
            orderY = 3.4f;
            order = order - 5;
        }
        Vector3 reVec3 = new Vector3(Vec3.x+0.4f + 1.5f*order, Vec3.y + orderY, 1);
        return reVec3;
    }
    public void SetFalse (GameObject obj) // 옵젝 비활성화 함수
    {
        obj.SetActive(false);
        //return obj;
    }

    public void SetTrue (GameObject obj) // 옵젝 활성화 함수
    {
        obj.SetActive(true);
    }

    public void GetItem (int Itemcode) // 아이템을 획득하면 옵젝을 활성화하고 소유여부를 1로 조정한다
    {
        Inventory[Itemcode - 1].Obj.SetActive(true);
        Inventory[Itemcode - 1].Ininven = 1;
    }

    public void UseItem(int Itemcode) // 아이템을 사용했다는 의미로 구조체 Ininven 값을 2로 조정
    {
        Inventory[Itemcode - 1].Ininven = 2;
    }


    public int CheckItem (int Itemcode) // 아이템이 있는지 확인하기위해 사용. 0=없음 1=있음 2=있었지만 사용함
    {
        return Inventory[Itemcode - 1].Ininven;
    }

    //public void LoadImage(int itemcode, string Image)
    //{
    //    Inventory[itemcode].Obj.GetComponent<SpriteRenderer>().sprite;
    //}
}
