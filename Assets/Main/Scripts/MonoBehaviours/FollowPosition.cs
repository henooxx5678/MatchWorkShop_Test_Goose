using UnityEngine;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    public class FollowPosition : MonoBehaviour {

        public bool followX;
        public bool followY;
        public bool followZ;

        [Header("REFS")]
        public Transform target;

        void Update () {

            Vector3 pos = transform.position;
            Vector3 targetPos = target.position;

            if (followX) {
                pos.x = targetPos.x;
            }

            if (followY) {
                pos.y = targetPos.y;
            }

            if (followZ) {
                pos.z = targetPos.z;
            }

            transform.position = pos;

        }

    }
}
