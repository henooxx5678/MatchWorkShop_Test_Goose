using Math = System.Math;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour {

        [SerializeField] float _walkSpeed = 1f;
        [SerializeField] float _jumpForce = 1f;

        [Header("REFS")]
        [SerializeField] Animator _spriteAnimator;

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
        public bool IsWalking {get; private set;} = false;

        // player controlling
        int _currentHorizontalMoveDirection = 0;
        bool _isTryingToJump = false;

        void FixedUpdate () {

            IsWalking = false;

            if (GameSceneManager.current.IsRunning) {
                // player controlled movements
                if (_currentHorizontalMoveDirection != 0) {
                    Vector2 walkVelocity = Vector2.right * _currentHorizontalMoveDirection * _walkSpeed;
                    transform.position += (Vector3) walkVelocity * Time.fixedDeltaTime * Time.timeScale;
                    IsWalking = true;
                }

                if (_isTryingToJump) {

                    if (IsOnGround) {
                        Rgbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                    }

                    _isTryingToJump = false;
                }
            }

        }

        void Update () {

            // === Animation ===
            _spriteAnimator.SetBool("IsWalking", IsWalking);

            // === Input ===
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

        void OnTriggerEnter2D (Collider2D other) {
            if (other.tag == "Pickable Item") {
                PickableItem pickableItem = other.gameObject.GetComponent<PickableItem>();

                if (pickableItem != null) {
                    GameSceneManager.current.playerInventory.AddItem(pickableItem.item);
                    Destroy(pickableItem.gameObject);
                }
            }
        }



    }

}
