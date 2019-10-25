using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public MovePattern movePattern;
    public GameState timeScaleProvider;
    public bool freezed;
    public float baseSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!freezed)
            movePattern.step(Time.fixedDeltaTime * timeScaleProvider.timeScale * baseSpeed);
    }


}
