using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour // 카메라가 플레이어를 따라가게 하기 위한 코드
{
    public GameObject Mcamera;
    GameObject Player;
    public Vector3 PlayerLocation;
    public static Vector3 Camlocation;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Mcamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLocation = new Vector3(Player.transform.position.x, Player.transform.position.y,Mcamera.transform.position.z) ;
        Mcamera.transform.position = (PlayerLocation);
        Camlocation = Mcamera.transform.position;
    }

    //public static Vector3 GetCamLocation()
    //{
    //    return Mcamera.transform.position;
    //}
    
}
