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
    GameObject scanObject, CManager;
    public GameManager manager;
    GameObject Arrow;
    Vector3 Plocation;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        moveSpeed = 5f ;
        Debug.Log(Time.deltaTime);
        KeyCount = 0;
        animator = GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Arrow = GameObject.Find("Arrow");
        CManager = GameObject.Find("CameraManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionManager.Sin == 2) {
            if (CManager.GetComponent<CameraManager>().CheckItem(2) == 0)
            {
                if (KeyCount != 0)
                {
                    manager.Starttime();
                }
            }
        }
        Plocation = Player.transform.position;
        
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
                Arrow.transform.position = new Vector3(Plocation.x, Plocation.y + 1.2f, Plocation.z);
                Arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Player.transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
                KeyCount++;
                SideKey = 0;
                dirVec = Vector3.down;
                Arrow.transform.position = new Vector3(Plocation.x, Plocation.y + -0.9f, Plocation.z);
                Arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Player.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                KeyCount++;
                SideKey = -1;
                dirVec = Vector3.left;
                Arrow.transform.position = new Vector3(Plocation.x-0.8f, Plocation.y, Plocation.z);
                Arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Player.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                KeyCount++;
                SideKey = 1;
                dirVec = Vector3.right;
                Arrow.transform.position = new Vector3(Plocation.x + 0.8f, Plocation.y, Plocation.z);
                Arrow.transform.rotation = Quaternion.Euler(0, 0, -90);
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
            manager.Action(scanObject);
        }
    }

    public void Scan()
    {
        manager.Action(scanObject);
    }

    void FixedUpdate()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1.2f, LayerMask.GetMask("Object")); //물체는 Layers를 Object로 바꿔서 구분한다

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
