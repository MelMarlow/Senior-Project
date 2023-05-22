using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //public
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    //immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //push
        protected Vector3 pushDirection;

    //all fighters can receive dmg & die
   
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
        lastImmune = Time.time;
        hitpoint -= dmg.damageAmount;
        pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;


        //commented out until error is fixed
        //GameManager.instance.ShowText(dmg.damageAmount.ToString(), 35, Color.red, transform.position, Vector3.zero, 0.5f);
       
        //Debug.Log("-1 Health");

        if(hitpoint <= 0)
        {
            hitpoint = 0;
            Death();
        }
        }
    }
    

    protected virtual void Death()
    {

    }
    
}
