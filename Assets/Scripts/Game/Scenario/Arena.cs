using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Arena : MonoBehaviour {

    public float width;

    LineRenderer line;

    void Awake() {
        line = GetComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.loop = true;
        SetupPositions();
    }

    void SetupPositions() {
        float height = width * 9 / 16;
        Vector3[] linePos = new Vector3[4];
        linePos[0] = new Vector3(-width / 2, height / 2);
        linePos[1] = new Vector3(width / 2, height / 2);
        linePos[2] = new Vector3(width / 2, -height / 2);
        linePos[3] = new Vector3(-width / 2, -height / 2);
        line.positionCount = 4;
        line.SetPositions(linePos);
    }
}
