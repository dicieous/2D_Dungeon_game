using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 movevalue;
    private RaycastHit2D hit;
    public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //To take input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //To change the direction of the face
        movevalue = new Vector3(x, y, 0);
        if (movevalue.x > 0)
        {
            transform.localScale = Vector3.one;
        }else if (movevalue.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //To Raycast detect walls in x direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movevalue.x,0), Mathf.Abs(movevalue.x * Time.deltaTime), LayerMask.GetMask("Hero", "Blocking"));
        if (hit.collider == null)
        {
            //To move
            transform.Translate(movevalue.x * Time.deltaTime, 0,0);
        }

        //To Raycast detect walls in y direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movevalue.y), Mathf.Abs(movevalue.y * Time.deltaTime), LayerMask.GetMask("Hero", "Blocking"));
        if (hit.collider == null)
        {
            //To move
            transform.Translate(0,movevalue.y * Time.deltaTime,0);
        }

        float a=0;
        if (x != 0)
        {
            a = x;
        }else if (y != 0)
        {
            a = y;
        }
        playerAnimator.SetFloat("Speed",Mathf.Abs(a));

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
