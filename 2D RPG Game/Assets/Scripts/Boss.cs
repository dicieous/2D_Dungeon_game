using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public float[] minionSpeed = { 2.5f, -2.5f };
    public float distance = 1.0f;
    public Transform[] minions;

    private void Update()
    {
        for(int i=0;i<minions.Length;i++)
        {
            minions[i].position = transform.position + new Vector3(-Mathf.Cos(Time.time * minionSpeed[i]) * distance, Mathf.Sin(Time.time * minionSpeed[i]) * distance, 0);
        }
    }
       
}
