using Math = System.Math;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DoubleHeat.Utilities;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour {

        [SerializeField] float walkSpeed = 1f;
        [SerializeField] float jumpForce = 1f;
        [SerializeField] LayerMask collisionLayerMask;

        Rigidbody2D _rb;
        public Rigidbody2D Rgbody {
            get {
                if (_rb == null) {
                    _rb = GetComponent<Rigidbody2D>();
                }
                return _rb;
            }
        }

        public bool IsOnGround {get; private set;} = false;

        // player controlling
        private int _currentHorizontalMoveDirection = 0;
        private bool _isTryingToJump = false;

        void FixedUpdate () {
            Vector2 walkVelocity = Vector2.right * _currentHorizontalMoveDirection * walkSpeed;
            transform.position += (Vector3) walkVelocity * Time.fixedDeltaTime * Time.timeScale;

            if (_isTryingToJump) {

                if (IsOnGround) {
                    Rgbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }

                _isTryingToJump = false;
            }

        }

        void Update () {

            _currentHorizontalMoveDirection = (int) Input.GetAxisRaw("Horizontal");

            if (_isTryingToJump == false) {
                _isTryingToJump = Input.GetButtonDown("Jump");
            }
        }

        void OnCollisionStay2D (Collision2D collision) {
            if (collision.collider.tag == "Ground") {
                IsOnGround = true;
            }
        }

        void OnCollisionExit2D (Collision2D collision) {
            if (collision.collider.tag == "Ground") {
                IsOnGround = false;
            }
        }

    }

}
