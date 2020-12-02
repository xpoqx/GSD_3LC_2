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
    // Start is called before the first frame update
    void Start()
    {
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
            moveSpeed = 3.8f;
        }
        else if (KeyCount== 1 || KeyCount >=3 )
        {
            moveSpeed = 5f;
        }
        else if (KeyCount == 0)
        {
            moveSpeed = 0f;
        }
        KeyCount = 0;
        animator.speed = moveSpeed / 4f;

        if (Input.GetKey(KeyCode.W))
        {
            Player.transform.Translate(0, moveSpeed * Time.deltaTime, 0);
            KeyCount++;
            SideKey = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Player.transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
            KeyCount++;
            SideKey = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Player.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            KeyCount++;
            SideKey = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player.transform.Translate(moveSpeed * Time.deltaTime, 0,0);
            KeyCount++;
            SideKey = 1;
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
}
