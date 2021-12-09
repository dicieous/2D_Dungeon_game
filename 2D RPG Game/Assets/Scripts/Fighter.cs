using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //Public Fields
    public int hitPoint = 10;
    public int maxHitPoint = 10;
    public float pushrecoveryspeed = 0.2f;

    //Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Push
    protected Vector3 pushDirection;

    //All Fighters can recieve damage and Die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 14, Color.red, transform.position + new Vector3(0.5f,0.1f), Vector3.zero, 0.5f);

            if (hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
}
