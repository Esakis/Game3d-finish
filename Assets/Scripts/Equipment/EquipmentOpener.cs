using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentOpener : MonoBehaviour
{
    public GameObject EquipmentUI;
    public GameObject[] AnotherObjets;
    public bool IsOpen;
    void Awake()
    {
        EquipmentUI.SetActive(false);
        

     //   for (int i = 0; i < AnotherObjets.Length; i++)
     //   {
     //       AnotherObjets[i].SetActive(true);
     //   }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            IsOpen = !IsOpen;
            EquipmentUI.SetActive(!EquipmentUI.activeInHierarchy);

            for (int i = 0; i < AnotherObjets.Length; i++)
            {
                AnotherObjets[i].SetActive(!AnotherObjets[i].activeInHierarchy);
            }
        }
        
    }
}
