using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    ItemsDataBase Database;
    public EquipmentManager EM;
   
    int goldCounter = 0;
    int bottleCounter = 0;
    public GUISkin skin;

    public int ID;
    Item item;

    Transform Player;

    bool CanPickUp;

    public GameObject CanPickUpInfo;

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

                    bottleCounter++;
                    PlayerPrefs.SetInt("TextCounterBottle", bottleCounter);
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
        Player = GameObject.Find("Hero1").transform;
    }

    private void OnGUI()
    {
        if (CanPickUp == true)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), "E pick up item", skin.GetStyle("PickUpStyle"));
        }
    }
}