using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountain : collidable
{
    public int healingAmount = 1;
    private float coolDown = 1.0f;
    private float lastHeal;

    protected override void onCollide(Collider2D coll)
    {
        if (coll.name != "Player")
        {
            return;
        }
        if (Time.time - lastHeal > coolDown)
        {
            lastHeal = Time.time;
            GameManager.instance.player.Heal(healingAmount);
            
        }
    }
}
