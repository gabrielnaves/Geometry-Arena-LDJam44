using UnityEngine;

namespace Utility {

    public class ScreenDimensions : MonoBehaviour {

        static public ScreenDimensions instance { get; private set; }

        public Vector2 referenceResolution;

        [ViewOnly] public float originalWidth;
        [ViewOnly] public float currentWidth;
        [ViewOnly] public float currentHeight;
        [ViewOnly] public float widthRatio;

        void Awake() {
            instance = (ScreenDimensions)Singleton.Setup(this, instance);
            CalculateDimensions();
        }

    #if UNITY_EDITOR
        void Update() {
            CalculateDimensions();
        }
    #endif

        void CalculateDimensions() {
            currentHeight = Camera.main.orthographicSize * 2;

            originalWidth = currentHeight * referenceResolution.x / referenceResolution.y;
            currentWidth = currentHeight * Screen.width / Screen.height;

            if (originalWidth != 0)
                widthRatio = currentWidth / originalWidth;
        }
    }
}

