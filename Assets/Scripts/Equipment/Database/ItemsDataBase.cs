using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDataBase : MonoBehaviour
{
    public List<Item> ItemDataBase = new List<Item>();
    public List<Item> PlayerItemsDataBase = new List<Item>();
    void Awake()
    {
        CreaterDataBase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreaterDataBase()
    {
        //ItemDataBase.Add(new Item("Aplle", "You can eat or throw in sb", Texture, 0, Item.itemType.food, 10, 20, 2, true));

    }
}
