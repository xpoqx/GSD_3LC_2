using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject Player;
    public float moveSpeed;
    public int KeyCount;
    Animator animator;
    public int SideKey;
    Rigidbody2D rigid;
    Vector3 dirVec;
    GameObject scanObject;
    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        moveSpeed = 5f ;
        Debug.Log(Time.deltaTime);
        KeyCount = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyCount == 2)
        {
            if (manager.istalking)
            {
                moveSpeed = 0f;
            }
            else
            {
                moveSpeed = 3.8f;
            }
        }
        else if (KeyCount== 1 || KeyCount >=3 )
        {
            if (manager.istalking)
            {
                moveSpeed = 0f;
            }
            else
            {
                moveSpeed = 5f;
            }
        }
        else if (KeyCount == 0)
        {
            moveSpeed = 0f;
        }
        KeyCount = 0;
        animator.speed = moveSpeed / 4f;
        if (manager.istalking is false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Player.transform.Translate(0, moveSpeed * Time.deltaTime, 0);
                KeyCount++;
                SideKey = 0;
                dirVec = Vector3.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Player.transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
                KeyCount++;
                SideKey = 0;
                dirVec = Vector3.down;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Player.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                KeyCount++;
                SideKey = -1;
                dirVec = Vector3.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Player.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                KeyCount++;
                SideKey = 1;
                dirVec = Vector3.right;
            }
            if (SideKey != 0)
            {
                transform.localScale = new Vector3(SideKey, 1, 1);
                animator.Play("SideWalk");
            }
            else
            {
                animator.Play("DownWalk");
            }
        }
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            manager.Action(scanObject); // 오브젝트 앞에서 스페이스바를 누르면 그 오브젝트의 이름 출력
        }
    }

    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, dirVec * 1.0f, Color.red);
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object")); //물체는 Layers를 Object로 바꿔서 구분한다

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
