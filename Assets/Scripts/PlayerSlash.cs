using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    //swing
   private Animator anim;
   private float cooldown;
   private float lastSwing;


    private void Start()
    {
        anim = GetComponent<Animator>(); // Assign the Animator component of the current GameObject
    }


   protected virtual void Update()
   {

    if(Input.GetKeyDown(KeyCode.Space))
    {
        if(Time.time - lastSwing > cooldown)
        {
            lastSwing = Time.time;
            Swing();
        }
    }

   

   }

   private void Swing()
   {
        if (anim != null) 
        {
            anim.SetTrigger("side_slash");
        }
   }
}
