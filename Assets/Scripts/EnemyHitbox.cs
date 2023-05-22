using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //damage
    public int damage = 1;
    public float pushForce = 3;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.name == "Player")
        {
            //create new dmg object before sending it to the player
            // create a new damage object then send it to the fighter that's been hit
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);

                //checks that the above is working correctly
                //Debug.Log(dmg + " damage taken");
        } 
    }
}
