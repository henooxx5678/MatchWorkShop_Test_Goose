using UnityEngine;
using UnityEngine.UI;

namespace ProjectTestGoose {

    [RequireComponent(typeof(Image))]
    public class ImageColorSetter : MonoBehaviour {

        [SerializeField] string colorLabel;

        Image _targetImage;
        public Image TargetImage {
            get {
                if (_targetImage == null) {
                    _targetImage = GetComponent<Image>();
                }
                return _targetImage;
            }
        }

        void OnValidate () {
            if (TargetImage != null) {

                Color result;

                if (Global.current.labeledColors.GetColorByLabel(colorLabel, out result)) {
                    TargetImage.color = result;
                }
            }
        }

    }
}
