using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    ItemsDataBase Database;
    public EquipmentManager EM;
   
    public int goldCounter = 0;
    public int bottleCounter = 0;
    public GUISkin skin;

    public int ID;
    Item item;

    Transform Player;

    bool CanPickUp;

    public GameObject CanPickUpInfo;

    public Slider FoodBar;

    void Awake()
    {
        GetObject();
        item = Database.ItemDataBase[ID];
        CanPickUpInfo.SetActive(false);
    }


    void Update()
    {
        if (Vector3.Distance(Player.position, transform.position) < 2f)
        {

            CanPickUp = true;
            CanPickUpInfo.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpItem();

                if (transform.gameObject.tag == "Gold")
                {
                    Destroy(transform.gameObject);
                    
                    goldCounter++;
                    PlayerPrefs.SetInt("TextCounterCoin", goldCounter);
                }

                else if (transform.gameObject.tag == "Food")
                {
                    Destroy(transform.gameObject);
                    FoodBar.value++;
                    bottleCounter++;
                    

                    PlayerPrefs.SetInt("TextCounterBottle", bottleCounter);
                }

                else if (transform.gameObject.tag == "Key")
                {
                    Destroy(transform.gameObject);
                    Move.hasKey = true;
                 
                }
                else if (transform.gameObject.tag == "Rest")
                {
                    Destroy(transform.gameObject);          
                }

            }
        }
        else
        {
            CanPickUp = false;
            CanPickUpInfo.SetActive(false);
        }

    }
 
    



    void PickUpItem()
    {
        for (int i = 0; i < Database.PlayerItemsDataBase.Count; i++)
        {
            if (Database.PlayerItemsDataBase[i].ItemName == "")
            {
                Database.PlayerItemsDataBase[i] = item;
                EM.transform.GetChild(i).GetComponent<Slot>().SetSlot();
                break;
            }
        }
    }




    void GetObject()
    {
        Database = GameObject.Find("ItemsData").GetComponent<ItemsDataBase>();
        Player = GameObject.Find("Player").transform;
    }

    private void OnGUI()
    {
        if (CanPickUp == true)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), "E pick up item", skin.GetStyle("PickUpStyle"));
        }
    }
}