using UnityEngine;

namespace Utility {

    public class RectRandom : MonoBehaviour {

        public float width;
        public float height;
        public bool scaleWithScreenDimensions;
        public bool showGizmos;

        void Start() {
            if (scaleWithScreenDimensions) {
                width *= ScreenDimensions.instance.widthRatio;
            }
        }

        public Vector3 RandomVector3Point() {
            return RandomPoint();
        }

        public Vector2 RandomPoint() {
            var pos = transform.position;
            return new Vector2(Random.Range(pos.x - width / 2, pos.x + width / 2),
                            Random.Range(pos.y - height / 2, pos.y + height / 2));
        }

        public Vector2 RandomPointInBounds() {
            Vector2 randomPoint = RandomPoint();
            float value = Random.value;
            if (value < 0.25f)
                randomPoint.x = transform.position.x - width / 2;
            else if (value < 0.5f)
                randomPoint.x = transform.position.x + width / 2;
            else if (value < 0.75f)
                randomPoint.y = transform.position.y - height / 2;
            else
                randomPoint.y = transform.position.y + height / 2;
            return randomPoint;
        }

        void OnDrawGizmosSelected() {
            if (showGizmos) {
                Gizmos.color = new Color(1, 1, 1, 0.3f);
                Gizmos.DrawCube(transform.position, new Vector3(width, height, 0.1f));
            }
        }
    }
}
