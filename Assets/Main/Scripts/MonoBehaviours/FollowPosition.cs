using UnityEngine;

namespace ProjectTestGoose {

    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    public class FollowPosition : MonoBehaviour {

        public bool followX;
        public bool followY;
        public bool followZ;

        public Vector3 offset;

        [Header("REFS")]
        public Transform target;

        void Update () {

            Vector3 pos = transform.position;
            Vector3 targetPos = target.position;

            if (followX) {
                pos.x = targetPos.x + offset.x;
            }

            if (followY) {
                pos.y = targetPos.y + offset.y;
            }

            if (followZ) {
                pos.z = targetPos.z + offset.z;
            }

            transform.position = pos;

        }

    }
}
