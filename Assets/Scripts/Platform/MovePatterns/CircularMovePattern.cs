﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovePattern : MovePattern
{
    public Transform  rotateAround;

    public override void step(float stepSize)
    {
        transform.RotateAround(rotateAround.position, new Vector3(0,0,1), stepSize);
       
        transform.eulerAngles = Vector3.zero;
       

    }
}
