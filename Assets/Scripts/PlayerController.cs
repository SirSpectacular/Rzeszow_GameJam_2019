using PlatformShift.Move;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformShift.Controll {

    public class PlayerController : MonoBehaviour {

        [SerializeField] Mover mover = null;
        [SerializeField] float runSpeed = 10f;

        float horizontalInput = 0f;
        bool jumpInput = false;
        bool jumpPressed = false;


        private void Update() {
            if(!jumpInput)
                jumpInput = Input.GetButtonDown("Jump");
            horizontalInput = Input.GetAxis("Horizontal");
            jumpPressed = Input.GetButton("Jump"); 

            if (Input.GetButtonDown("Cancel")) {
                SceneManager.LoadScene(0);
            }
        }
        private void FixedUpdate() {
            mover.Move(horizontalInput * runSpeed, jumpInput,jumpPressed);
            jumpInput = false;
        }
    }
}