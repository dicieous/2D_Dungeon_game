using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null){
                continue;
            }

            onCollide(hits[i]);

            hits[i] = null;
        }
    }

    protected virtual void onCollide(Collider2D coll)
    {
        Debug.Log("Player");
    }
}