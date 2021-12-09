using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 movevalue;
    protected RaycastHit2D hit;
    protected float ySpeed=0.75f;
    protected float xSpeed = 1.0f;
    public Animator npcAnimator;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        movevalue = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);
        if (movevalue.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (movevalue.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //add push vector, if any
        movevalue += pushDirection;

        //slow down the push speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushrecoveryspeed);

        //To Raycast detect walls in x direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movevalue.x, 0), Mathf.Abs(movevalue.x * Time.deltaTime), LayerMask.GetMask("Hero", "Blocking"));
        if (hit.collider == null)
        {
            //To move
            transform.Translate(movevalue.x * Time.deltaTime, 0, 0);
        }

        //To Raycast detect walls in y direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movevalue.y), Mathf.Abs(movevalue.y * Time.deltaTime), LayerMask.GetMask("Hero", "Blocking"));
        if (hit.collider == null)
        {
            //To move
            transform.Translate(0, movevalue.y * Time.deltaTime, 0);
        }
    }
}
