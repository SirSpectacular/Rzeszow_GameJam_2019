using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovePattern : MovePattern
{
    public Transform  rotateAround;

    public override void step(float stepSize)
    {
        Debug.Log(stepSize);
        transform.RotateAround(rotateAround.position, new Vector3(0,0,1), stepSize);
        Debug.Log(transform);

        transform.eulerAngles = Vector3.zero;
        Debug.Log(transform);

    }
}
