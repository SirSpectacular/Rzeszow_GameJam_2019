﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovePattern : MovePattern
{
    public Transform pointA;
    public Transform pointB;
    private Transform moveTowards;
    private float stepSupression = 0.01f;

    void Awake()
    {
        moveTowards = pointA;
    }

    public override void step(float stepSize) 
    {
        Vector3 move = (moveTowards.position - transform.position).normalized * stepSize * stepSupression;
        transform.Translate(move);

        if ((moveTowards.position - transform.position).magnitude < move.magnitude  )
        {
            if (moveTowards == pointA)
            {
                moveTowards = pointB;
            }
            else
            {
                moveTowards = pointA;
            }
        }
    }
}
