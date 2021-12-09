using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : collectable
{
    public Sprite emptyChest;
    public int coinAmount = 10;

    protected override void onCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.coins += coinAmount;
            GameManager.instance.ShowText(coinAmount + " Coins!",18,Color.yellow,transform.position, Vector3.up*20,1.5f);
        }
    }
}
