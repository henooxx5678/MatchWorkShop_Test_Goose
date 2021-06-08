using System.Collections.Generic;

using UnityEngine;

namespace ProjectTestGoose {

    public class Global : SingletonMonoBehaviour<Global> {

        [Header("Labeled Colors")]
        public LabeledColors labeledColors;


        protected override void Awake () {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }


    }

}
