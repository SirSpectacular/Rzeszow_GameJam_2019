using UnityEngine;
using System.Collections;

public class TextFader : MonoBehaviour {

    Animator anim;

    void Start() {
        anim = gameObject.GetComponent<Animator>();
        anim.SetFloat("Direction", -1);
            
    }
 
    public void Fade() {

        float direction = -1f * anim.GetFloat("Direction");

        anim.SetFloat("Direction", direction);

        float startPoint = direction > 0 ? 0 : 1;

        anim.Play("Credits_Fade", 0, startPoint);
    }


    
}