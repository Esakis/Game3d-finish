using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    
    void Awake()
    {
        for(int i = 0; i<transform.childCount;i++)
        {
            transform.GetChild(i).name = "Slot" + 1;
            transform.GetChild(i).GetComponent<Slot>().ID = i;

        }
        
    }

    
}
