using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject Player;
    public float moveSpeed;
    public int KeyCount;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        moveSpeed = 5f ;
        Debug.Log(Time.deltaTime);
        KeyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyCount >= 2)
        {
            moveSpeed = 3f;
            KeyCount = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Player.transform.Translate(0, moveSpeed * Time.deltaTime, 0);
            KeyCount++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Player.transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
            KeyCount++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Player.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            KeyCount++;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player.transform.Translate(moveSpeed * Time.deltaTime, 0,0);
            KeyCount++;
        }
        moveSpeed = 5f;
        

    }
}
