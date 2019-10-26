using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlatformShift.Move {


    public class Mover : MonoBehaviour {

        [SerializeField] float jumpForce = 500;
        [SerializeField] float smoothTime = 0.03F;
        [SerializeField] LayerMask platform;
        [SerializeField] Transform platformCheckTransformLeft = null;
        [SerializeField] Transform platformCheckTransformRight = null;

        [SerializeField] float platformCheckRadious = 0.1f;
        [SerializeField] float fallMultiplayer = 3f;
        [SerializeField] float shortJumpMultiplayer = 4f;

        public UnityEvent onPlatformHit;
        public UnityEvent onPlatformLeft;
        [SerializeField] public Animator animator;
        public SpriteRenderer renderer;

       
        private bool isOnPlatform = false;
        private Rigidbody2D rigidBody = null;
        private Vector2 currentVelocity = Vector2.zero;
        
        void Awake() {
            rigidBody = GetComponent<Rigidbody2D>();
            onPlatformHit = new UnityEvent();
            onPlatformLeft = new UnityEvent();
        }

        void Update() {
            Vector2 platformCheckPointLeft = platformCheckTransformLeft.position;
            Vector2 platformCheckPointRight = platformCheckTransformRight.position;

            isOnPlatform = false;
            isOnPlatform = (Physics2D.Raycast(platformCheckPointLeft, -Vector2.up, platformCheckRadious) || Physics2D.Raycast(platformCheckPointRight, -Vector2.up, platformCheckRadious));
            animator.SetBool("is_grounded", isOnPlatform);
            animator.SetFloat("h_velocity", Math.Abs(rigidBody.velocity.x));
            animator.SetFloat("v_velocity", rigidBody.velocity.y);
                
        }

        public void Move(float horizontalInput, bool jumpInput, bool jumpPressed) {

            if (rigidBody.velocity.y < 0) {
                rigidBody.velocity += (Vector2.up * Physics2D.gravity.y * fallMultiplayer * Time.fixedDeltaTime);
            }
            if (rigidBody.velocity.y >0 && !jumpPressed) {
                rigidBody.velocity += (Vector2.up * Physics2D.gravity.y * shortJumpMultiplayer * Time.fixedDeltaTime);              
            }

            if (rigidBody.velocity.x < -0.1)
            {
                renderer.flipX = true;
            }
            if (rigidBody.velocity.x > 0.1)
            {
                renderer.flipX = false;
            }



            float verticalVelocity = rigidBody.velocity.y;



            Vector2 targetVelocity = new Vector2(horizontalInput, verticalVelocity);

            rigidBody.velocity =  Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref currentVelocity, smoothTime);


            if (jumpInput && isOnPlatform) {
                rigidBody.AddForce(new Vector2(0f, jumpForce));
                isOnPlatform = false;
            }
         
        }
    
        private void OnCollisionEnter2D(Collision2D collision) {
            transform.SetParent(collision.gameObject.transform);
            onPlatformHit.Invoke();
        }

        private void OnCollisionExit2D(Collision2D collision) {
            transform.SetParent(null);

            if (collision.gameObject.GetComponentInParent<FragilePlatform>() != null) {
                Destroy(collision.gameObject);
            }

            onPlatformLeft.Invoke();
        }
    }
}