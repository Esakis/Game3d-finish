using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KrrrAI : MonoBehaviour
{
    public Transform Player;
    static Animator anim;
    public Slider healthbarAI;
    void Awake()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (healthbarAI.value <= 0) return;

        Vector3 direction = Player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(Player.position, this.transform.position) < 20 && angle < 90)
        {

            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("isIdle", false);
            if (direction.magnitude > 2.5)
            {
                this.transform.Translate(0, 0, 0.02f);
                anim.SetBool("isWalking", true);
            }

        }
    }
}
