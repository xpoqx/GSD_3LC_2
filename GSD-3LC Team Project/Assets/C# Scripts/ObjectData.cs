using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 오브젝트들을 구분하기위한 정보를 입력하기위한 코드.

public class ObjectData : MonoBehaviour
{
    public int id;
    public bool isNpc;
    public bool isItem;
    public int itemcode; // 획득 가능한 아이템의 코드와 매치시켜줄 오브젝트의 변수
    public bool Interactive;
    public int SinNumber;
    public bool isShared;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
