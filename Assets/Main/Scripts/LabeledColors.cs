using System.Collections.Generic;

using UnityEngine;

namespace ProjectTestGoose {

    [CreateAssetMenu(fileName = "LabeledColors", menuName = "ScriptableObjects/LabeledColors", order = 1)]
    public class LabeledColors : ScriptableObject {

        public List<LabeledColor> labeledColors;

        public bool GetColorByLabel (string label, out Color result) {
            foreach (LabeledColor labeledColor in labeledColors) {
                if (labeledColor.label == label) {
                    result = labeledColor.color;
                    return true;
                }
            }
            result = Color.white;
            return false;
        }


        [System.Serializable]
        public class LabeledColor {
            public string label;
            public Color color;
        }

    }
}
