using System.Collections;
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
        if (Input.GetKey(KeyCode.Mouse1))
        {
            timeScale = timeSlow / timeModifier;
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            timeScale = timeFast * timeModifier;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Mouse1))
        {
            timeScale = 1;
        }
    }
}
