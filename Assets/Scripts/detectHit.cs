using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectHit : MonoBehaviour
{
    public Slider healtbar;
    Animator animator;
    public bool GetHit;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Weapon")
        {

            GetHit = true;
            if (GetHit == true)
            {
                animator.SetBool("GetHit", true);

                healtbar.value -= 5;
                if (healtbar.value <= 0)
                {
                    animator.SetBool("isDead", true);
                }
                GetHit = false;
            }

        }
            
           
            
    

    }


    private void OnTriggerExit(Collider other)
    {
        GetHit = false;
    }


    void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
