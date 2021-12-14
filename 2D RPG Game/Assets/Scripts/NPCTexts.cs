using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTexts : collidable
{
    public string message;

    private float coolDown = 5.0f;
    private float lastSpoke = -5.0f;

    protected override void onCollide(Collider2D coll)
    {
        if (Time.time - lastSpoke > coolDown)
        {
            lastSpoke = Time.time;
            GameManager.instance.ShowText(message, 20, Color.white, transform.position+new Vector3(0,0.3f,0), Vector3.zero, coolDown);
        }
    }
}
