using Math = System.Math;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    public class EndGameTrigger : MonoBehaviour {

        void OnCollisionEnter2D (Collision2D collision) {
            if (collision.collider.tag == "Player") {
                GameSceneManager.current.PopOutEndGameConfirmation();
            }
        }

    }

}
