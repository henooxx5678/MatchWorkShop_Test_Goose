using Math = System.Math;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    public class PickableItem : MonoBehaviour {

        public Item item;

        [SerializeField] SpriteRenderer _spriteRenderer;


        void OnValidate () {
            if (_spriteRenderer != null && item != null) {
                _spriteRenderer.sprite = item.icon;
            }
        }
    }
}
