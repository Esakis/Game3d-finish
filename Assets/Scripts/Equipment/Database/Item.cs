using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Item
{
    public enum itemType
    {
        food,
        weapon,
        rest

    }

    public string ItemName;
    public string ItemDescription;
    public Sprite Texture;
    public int ID;
    public itemType ItemType;
    public float Damage;
    public float Food;
    public float Price;
    public bool Eatable;

    public Item(string ItemName, string ItemDescription, Sprite Texture, int ID, itemType ItemType, float Damage, float Food, float Price, bool Eatable)
    {
        this.ItemName = ItemName;
        this.ItemDescription = ItemDescription;
        this.Texture = Texture;
        this.ID = ID;
        this.ItemType = ItemType;
        this.Damage = Damage;
        this.Food = Food;
        this.Price = Price;
        this.Eatable = Eatable;

    }


}
