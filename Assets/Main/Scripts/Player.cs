using Math = System.Math;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DoubleHeat.Utilities;

namespace ProjectTestGoose {

    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour {

        [SerializeField] float walkSpeed = 1f;
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

        // player controlling
        private int _currentHorizontalMoveDirection = 0;

        void FixedUpdate () {
            Vector2 walkVelocity = Vector2.right * _currentHorizontalMoveDirection * walkSpeed;
            transform.position += (Vector3) walkVelocity * Time.fixedDeltaTime * Time.timeScale;
        }

        void Update () {

            _currentHorizontalMoveDirection = (int) Input.GetAxisRaw("Horizontal");

        }

    }

}
