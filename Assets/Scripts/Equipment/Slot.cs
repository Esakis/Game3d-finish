using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    ItemsDataBase Database;
    public int ID;
    Image Icon;
    Item item;
    void Awake()
    {
        GetObjects();
        SetSlot();
    }

    // Update is called once per frame
    public void SetSlot()
    {
        if (Database.PlayerItemsDataBase[ID].ItemName != "")
        {
            Icon.gameObject.SetActive(true);
            Icon.sprite=Database.PlayerItemsDataBase[ID].Texture;
        }
        else
        {
            Icon.gameObject.SetActive(false);
            Icon.sprite = null;
        }
        
    }

    void GetObjects()
    {
        Database = GameObject.Find("ItemsData").GetComponent<ItemsDataBase>();
        Icon = transform.GetChild(0).GetComponent<Image>();

    }
}
