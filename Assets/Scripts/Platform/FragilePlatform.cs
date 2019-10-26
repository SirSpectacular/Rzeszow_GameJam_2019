using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour{
    
    public void DestroyWhenLeft() {
        Destroy(gameObject);
    }
}
