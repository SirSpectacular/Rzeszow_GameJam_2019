using PlatformShift.Move;
using UnityEngine;

namespace PlatformShift.Controll {

    public class PlayerController : MonoBehaviour {

        [SerializeField] Mover mover = null;
        [SerializeField] float runSpeed = 10f;

        float horizontalInput = 0f;
        bool jumpInput = false;
        bool jumpPressed = false;


        private void Update() {
            jumpInput = Input.GetButtonDown("Jump");
            horizontalInput = Input.GetAxis("Horizontal");
            jumpPressed = Input.GetButton("Jump");
        }
        private void FixedUpdate() {
            mover.Move(horizontalInput * runSpeed, jumpInput,jumpPressed);
            jumpInput = false;
        }
    }
}