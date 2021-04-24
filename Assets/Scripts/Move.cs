using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    Rigidbody RB;
    public CharacterController characterControler;
    GameObject Cam;
    public EquipmentOpener EO;
    private Animator animator;

    public float MoveSpeed = 0.18f;
    public float JumpForce = 400;
    public float FastSpeed = 0.4f;

    public float MouseSensitivity = 12;

    float Vertical;
    float Horizontal;

    public float MouseX;
    public float MouseY;
    public float MaxRotY = 40.0f;

    public bool IsGrounded;
    public static bool hasKey = false;
    



    void Awake()
    {

    
        RB = GetComponent<Rigidbody>();
        characterControler = GetComponent<CharacterController>();
        Cam = transform.Find("Camera").gameObject;
        animator = GetComponent<Animator>();


    }

    void Update()
    {
       
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseX = Input.GetAxis("Mouse X");
        MouseY -= Input.GetAxis("Mouse Y");


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveSpeed += FastSpeed;
            animator.SetBool("Fast", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveSpeed -= FastSpeed;
            animator.SetFloat("Speed", 0.15f);
            animator.SetBool("Fast", false);
        }

        RB.MovePosition(transform.position + transform.forward * Vertical * MoveSpeed + (transform.right * Horizontal * MoveSpeed));
        RB.MoveRotation(RB.rotation * Quaternion.Euler(new Vector3(0, MouseX * MouseSensitivity, 0)));

        MouseY = Mathf.Clamp(MouseY, -MaxRotY, MaxRotY);
        Cam.transform.localRotation = Quaternion.Euler(MouseY, 0, 0);
        CharacterAnimation(Horizontal, Vertical);

        if (EO.IsOpen == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;


        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            RB.MovePosition(transform.position + transform.forward * Vertical * MoveSpeed + (transform.right * Horizontal * MoveSpeed));
            RB.MoveRotation(RB.rotation * Quaternion.Euler(new Vector3(0, MouseX * MouseSensitivity, 0)));

            MouseY = Mathf.Clamp(MouseY, -MaxRotY, MaxRotY);
            Cam.transform.localRotation = Quaternion.Euler(MouseY, 0, 0);
            CharacterAnimation(Horizontal, Vertical);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
        }
    }

    private void CharacterAnimation(float Horizontal, float Vertical)
    {
        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(transform.up * JumpForce);
            animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Atack");
        }

        if (Horizontal != 0f || Vertical != 0f)
        {
            animator.SetFloat("Speed", 0.15f);
        }
 
        else
        {
            animator.SetFloat("Speed", 0f);
        }

    }
   
}

