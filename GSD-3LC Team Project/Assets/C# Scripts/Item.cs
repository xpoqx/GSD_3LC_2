using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    
    GameObject item1;// ,item2, item3, item4, item5;
    public string itemname;
    bool get;
    /*void isgetted(GameObject item)
    {
        for(int i=0; i<items.Count; i++)
        {
            if(item == items[i])
            {
                get = true;
            }
            else
            {
                get = false;
            }
        }
    }*/
    
    
    private void Start()
    {
        item1 = GameObject.Find("item1");
    }
}