using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonAI : MonoBehaviour
{
    public Transform Player;
    static Animator animator;
    public Slider healthbarAI;
    public float TimeFly = 0f;
    public Transform[] GoPoints;
    public int GoPointsIndex;
    public float Dist;
    public float DSpeed;
    public bool StateGround;
    public int StateAnim;



    void Awake()
    {
        
        animator = GetComponent<Animator>();
        GoPointsIndex = 0;
        transform.LookAt(GoPoints[GoPointsIndex].position);
        StateGround = true;
        StateAnim = 0;
        

    }

   
    void Update()
    {
        
        if (TimeFly > 5 && TimeFly < 10 && StateGround == true)
        {
            TimeFly += 1 * Time.deltaTime;
            StateAnim = 1;
            animator.SetInteger("StateAnim", 1);
            transform.Translate(Vector3.up * DSpeed * Time.deltaTime);
        }
        else if (TimeFly > 9 && TimeFly < 20 && StateGround == true)
        {
            TimeFly += 1 * Time.deltaTime;
            StateAnim = 2;
            animator.SetInteger("StateAnim", 2);
            transform.Translate(Vector3.forward * DSpeed * Time.deltaTime);
        }
        else if (TimeFly > 20 && TimeFly < 25 && StateGround == true)
        {
            TimeFly += 1 * Time.deltaTime;
            StateAnim = 3;
            animator.SetInteger("StateAnim", 3);

            transform.Translate(Vector3.forward * DSpeed * Time.deltaTime);
        }
        else if (TimeFly > 25 && StateGround == true)
        {
            TimeFly += 1 * Time.deltaTime;
            StateAnim = 4;
            animator.SetInteger("StateAnim", 4);
            transform.Translate(Vector3.down * DSpeed * Time.deltaTime);
            
            if (TimeFly > 30)
            {
                StateGround = false;
                animator.SetBool("StateGround", false);
            }
        }
        else if (TimeFly > 30 && StateGround == false)
        {
            TimeFly -= 1 * Time.deltaTime;
            StateAnim = 5;
            animator.SetInteger("StateAnim", 5);
            transform.Translate(Vector3.zero);
        }
        else if (TimeFly < 6)
        {
            StateAnim = 0;
            TimeFly += 1 * Time.deltaTime;
            animator.SetFloat("DSpeed", 2f);
            StateGround = true;
            animator.SetBool("StateGround", true);
        }

        else
        {
            StateAnim = 0;
            TimeFly -= 1 * Time.deltaTime;   
            animator.SetFloat("DSpeed", 2f);
            Dist = Vector3.Distance(transform.position, GoPoints[GoPointsIndex].position);
            if (Dist < 4f)
            {
                IncreaseIndex();
            }
            Patrol();

        }

    }

    void Patrol()
    {
     
        transform.Translate(Vector3.forward * DSpeed * Time.deltaTime);
        
       
    }
    void IncreaseIndex()
    {
        GoPointsIndex++;
        if (GoPointsIndex >= GoPoints.Length)
        {
            GoPointsIndex = 0;
        }
        transform.LookAt(GoPoints[GoPointsIndex].position);

    }
}