using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererParticle : MonoBehaviour {

    LineRenderer line;
    Vector3 velocity_ = Vector3.zero;

    public Vector3 velocity {
        get {
            return velocity_;
        }
        set {
            velocity_ = value;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg);
        }
    }

    public float size {
        get {
            return transform.localScale.x;
        }
        set {
            transform.localScale = new Vector3(value, value, value);
        }
    }

    public Vector3 position {
        get {
            return transform.position;
        }
        set {
            transform.position = value;
        }
    }

    public Color color {
        get {
            return line.startColor;
        }
        set {
            line.startColor = value;
            line.endColor = value;
        }
    }

    void Awake() {
        line = GetComponent<LineRenderer>();
    }

    public void Activate() {
        gameObject.SetActive(true);
    }
}
