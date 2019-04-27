using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility {

    [RequireComponent(typeof(LineRenderer))]
    public class LineRendererShape : MonoBehaviour {

        public int vertices = 3;
        public float radius = 1;
        public float angleOffset;

        LineRenderer line;

        void Awake() {
            ApplyConstraints();
            line = GetComponent<LineRenderer>();
            line.useWorldSpace = false;
            line.loop = true;
            SetupPositions();
        }

        void ApplyConstraints() {
            if (vertices < 3) vertices = 3;
        }

        void SetupPositions() {
            Vector3[] positions = new Vector3[vertices];
            float angle = angleOffset * Mathf.Deg2Rad;
            float angleDistance = 2 * Mathf.PI / vertices;
            for (int i = 0; i < vertices; ++i, angle += angleDistance)
                positions[i] = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
            line.positionCount = vertices;
            line.SetPositions(positions);
        }

        void Update() {
            ApplyConstraints();
            SetupPositions();
        }
    }
}
