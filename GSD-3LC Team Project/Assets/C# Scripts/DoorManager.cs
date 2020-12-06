using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    GameObject TutDoor, Door1, Door2, Door3, Door4, Door5, Door6, SecDoor;
    GameObject[] Doors;
    // Start is called before the first frame update
    void Start()
    {
        TutDoor = GameObject.Find("DoorTutorial");
        Door1 = GameObject.Find("Door1");
        Door2 = GameObject.Find("Door2");
        Door3 = GameObject.Find("Door3");
        Door4 = GameObject.Find("Door4");
        Door5 = GameObject.Find("Door5");
        Door6 = GameObject.Find("Door6");
        SecDoor = GameObject.Find("SecretDoor");
        Doors = new GameObject[] {TutDoor, Door1, SecDoor, Door2, Door3, Door4, Door5, Door6 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DoorOpen(int DoorIndex1)
    {
        Debug.Log(Doors[DoorIndex1].name+"is opened");
        Doors[DoorIndex1 - 1].transform.rotation = Quaternion.Euler(0, 0, 0);
        if (DoorIndex1 == 3)
        {
            Doors[DoorIndex1 - 1].transform.rotation = Quaternion.Euler(0, 0, 90);
            GameObject.Find("Secret Wall").SetActive(false);
        }
    }
    public void Door123Open()
    {
        Debug.Log("Door 1,2,3 opened");
        Door1.transform.rotation = Quaternion.Euler(0, 0, 0);
        Door2.transform.rotation = Quaternion.Euler(0, 0, 0);
        Door3.transform.rotation = Quaternion.Euler(0, 0, 0);
    }


    public void ReadyOpen(int DoorIndex2)
    {
        Doors[DoorIndex2-1].GetComponent<ObjectData>().id = 998;
    }
}
