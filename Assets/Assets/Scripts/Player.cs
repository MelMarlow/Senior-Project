using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{

    //swing
    private Animator anim;
    private float lastSwing;
    private float cooldown;


    private void FixedUpdate()
    {
    //detects amount of movement as a float
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical"); 

        UpdateMotor(new Vector3(x, y, 0));
    }
}
