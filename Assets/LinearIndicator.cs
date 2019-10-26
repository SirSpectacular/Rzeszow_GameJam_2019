using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearIndicator : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;

    void Start()
    {
        Vector3 diff = pointA.position - pointB.position;
        float angle = Mathf.Atan2(diff.y, diff.x);
        float len = diff.magnitude;

        transform.localEulerAngles = new Vector3(0, 0, angle);
        transform.position = pointB.position + diff / 2;
        transform.localScale = new Vector3(transform.localScale.x * len, 1,1);
    }

}
