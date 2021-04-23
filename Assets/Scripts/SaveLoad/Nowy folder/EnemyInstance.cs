using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : MonoBehaviour
{
    public static EnemyInstance instance;
    
    void Awake()
    {
        
        if (!instance)
        {
            
            DontDestroyOnLoad(transform.root);
            DontDestroyOnLoad(gameObject);



            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}