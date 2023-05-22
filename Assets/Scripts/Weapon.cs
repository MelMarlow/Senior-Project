using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
   //damage structure
   public int damagePoint = 1;
   public float pushForce = 2.0f; 

   //animation
   public SpriteRenderer spriteRenderer;

   //swing
   private Animator anim;
   private float cooldown;
   private float lastSwing;

    //ensures you're getting to current weapon model upon starting a scene
   protected override void Start()
   {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
   }

    //ensures you can't swing too fast
   protected override void Update()
   {
    base.Update();


    if(Input.GetKeyDown(KeyCode.Space))
    {
        if(Time.time - lastSwing > cooldown)
        {
            lastSwing = Time.time;
            Swing();
        }
    }

   }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if(coll.name == "Player")
                return;
            
            // create a new damage object then send it to the fighter that's been hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            
            //Debug.Log("swing");
            coll.SendMessage("ReceiveDamage", dmg);
                //Debug.Log(coll.name);
            

        }
    }


   private void Swing()
   {
        anim.SetTrigger("side_slash");
   }

}
