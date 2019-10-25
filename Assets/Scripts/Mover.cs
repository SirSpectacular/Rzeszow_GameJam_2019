using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformShift.Move {


    public class Mover : MonoBehaviour {

        [SerializeField] float jumpForce = 1000000;
        [SerializeField] float smoothTime = 0.03F;


        private bool isOnPlatform = false;
        private Rigidbody2D rigidBody = null;
        private Vector2 currentVelocity = Vector2.zero;
        
        void Awake() {
            rigidBody = GetComponent<Rigidbody2D>();

            isOnPlatform = true;
        }

        void FixedUpdate() {

        }

        public void Move(float horizontalInput, bool jumpInput) {
            



            Vector2 targetVelocity = new Vector2(horizontalInput, rigidBody.velocity.y);

            rigidBody.velocity =  Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref currentVelocity, smoothTime);


            if (jumpInput && isOnPlatform) {
                rigidBody.AddForce(new Vector2(0f, jumpForce));
                isOnPlatform = false;
            }
        }
    }
}