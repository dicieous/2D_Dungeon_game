using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHItbox : collidable
{
    //damage to be done
    public int damage=1;
    public float pushForce=5;

    protected override void onCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.name == "Player")
        {
            //create a new damage object,before sending it to the fighter we've hit
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    } 
}
