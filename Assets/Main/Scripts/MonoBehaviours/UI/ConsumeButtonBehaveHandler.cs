using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    public class ConsumeButtonBehaveHandler : MonoBehaviour {

        [SerializeField] bool _countInRealtime = true;
        [SerializeField] float _holdToContinuousConsumeIntervalTime = 2f;

        bool _isHolding = false;
        float _holdingStartTime = 0f;
        int _currentConsumedCount = 0;

        float CurrentTime => _countInRealtime ? Time.realtimeSinceStartup : Time.time;

        public event EventHandler Consumed;


        void Update () {

            if (_isHolding) {
                if (CurrentTime - _holdingStartTime > (_currentConsumedCount + 1) * _holdToContinuousConsumeIntervalTime) {

                    if (Consumed != null) {
                        Consumed(this, EventArgs.Empty);
                    }
                    _currentConsumedCount++;
                }
            }
        }


        public void OnPointerClick (BaseEventData data) {
            if (_currentConsumedCount == 0) {

                if (Consumed != null) {
                    Consumed(this, EventArgs.Empty);
                }
            }
        }

        public void OnPointerDown (BaseEventData data) {
            _isHolding = true;
            _holdingStartTime = CurrentTime;
            _currentConsumedCount = 0;
        }

        public void OnPointerUp (BaseEventData data) {
            _isHolding = false;
        }

    }
}
