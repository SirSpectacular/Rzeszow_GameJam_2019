using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformShift.Move {


    public class Mover : MonoBehaviour {

        [SerializeField] float jumpForce = 500;
        [SerializeField] float smoothTime = 0.03F;
        [SerializeField] LayerMask platform;
        [SerializeField] Transform platformCheckTransform = null;
        [SerializeField] float platformCheckRadious = 0.1f;
        [SerializeField] float fallMultiplayer = 3f;
        [SerializeField] float shortJumpMultiplayer = 4f;

        public Event onPlatformHit;

        Vector2 platformCheckPoint;
        private bool isOnPlatform = false;
        private Rigidbody2D rigidBody = null;
        private Vector2 currentVelocity = Vector2.zero;
        
        void Awake() {
            rigidBody = GetComponent<Rigidbody2D>();

        }

        void Update() {
            platformCheckPoint = platformCheckTransform.position;

            isOnPlatform = false;
            isOnPlatform = Physics2D.Raycast(platformCheckPoint, -Vector2.up, platformCheckRadious);



        }

        public void Move(float horizontalInput, bool jumpInput, bool jumpPressed) {

            if (rigidBody.velocity.y < 0) {
                rigidBody.velocity += (Vector2.up * Physics2D.gravity.y * fallMultiplayer * Time.fixedDeltaTime);
            }
            if (rigidBody.velocity.y >0 && !jumpPressed) {
                rigidBody.velocity += (Vector2.up * Physics2D.gravity.y * shortJumpMultiplayer * Time.fixedDeltaTime);              
            }

            float verticalVelocity = rigidBody.velocity.y;



            Vector2 targetVelocity = new Vector2(horizontalInput, verticalVelocity);

            rigidBody.velocity =  Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref currentVelocity, smoothTime);


            if (jumpInput && isOnPlatform) {
                rigidBody.AddForce(new Vector2(0f, jumpForce));
                isOnPlatform = false;
            }
        }
    }
}