using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleIndicator : MonoBehaviour
{
    public Transform center;
    public Transform platform;

    void Start()
    {
        float radius = (center.position - platform.position).magnitude;
        transform.localScale = new Vector3(transform.localScale.x * radius * 2, transform.localScale.y * radius * 2, 0f);
        transform.position = center.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
