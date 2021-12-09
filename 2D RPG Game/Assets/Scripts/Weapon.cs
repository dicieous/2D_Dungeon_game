using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : collidable
{
    //damage struct
    public int[] damagePoints = { 1, 2, 4, 7, 9, 10, 15, 20};
    public float[] pushForce = { 1.0f, 1.3f, 1.5f, 1.9f, 4.0f, 2.3f, 2.0f, 2.5f };

    //Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //swing mechanics
    public Animator weaponanim;
    public float coolDown = 0.3f;
    public float lastSwing;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        //coolDown = coolDown - (weaponLevel * coolDown);
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastSwing > coolDown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void onCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
            {
                return;
            }

            //Create a new damage object,then we'll send it to the fighter we've hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoints[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing()
    {
        weaponanim.SetTrigger("Swing");
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.WeaponSprites[weaponLevel];
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel=level;
        spriteRenderer.sprite = GameManager.instance.WeaponSprites[weaponLevel];
    }
}
