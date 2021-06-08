using System;
using System.Collections.Generic;

using UnityEngine;

namespace ProjectTestGoose {

    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

        public enum KeepRule {
            KeepOld,
            KeepNew
        }

        static T _current = null;
        public static T current {
            get {
                if (_current == null) {
                    _current = (T) UnityEngine.Object.FindObjectOfType(typeof(T));
                }
                return _current;
            }
            set {
                _current = value;
            }
        }


        [Header("Singleton Options")]
        public KeepRule keepRule = KeepRule.KeepOld;


        protected virtual void Awake () {

            T thisInstance = GetComponent<T>();

            if (current == null) {
                current = thisInstance;
            }
            else if (current != thisInstance) {
                if (keepRule == KeepRule.KeepOld) {

                    if (this.gameObject != null)
                        Destroy(this.gameObject);

                }
                else if (keepRule == KeepRule.KeepNew) {

                    if (current.gameObject != null)
                        Destroy(current.gameObject);

                    current = thisInstance;
                }
            }

        }

        protected virtual void OnDestroy () {
            if (current == GetComponent<T>())
                current = null;
        }

    }
}
