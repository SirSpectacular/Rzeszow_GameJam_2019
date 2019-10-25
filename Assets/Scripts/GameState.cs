﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public float timeScale;
    public float timeModifier;
    public float timeSlow;
    public float timeFast;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            timeScale = timeSlow / timeModifier;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            timeScale = timeFast * timeModifier;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            timeScale = 1;
        }
    }
}
