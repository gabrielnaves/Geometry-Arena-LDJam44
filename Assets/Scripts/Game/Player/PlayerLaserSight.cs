using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayerLaserSight : MonoBehaviour {

    public PlayerData data;

    LineRenderer line;

    void Awake() {
        line = GetComponent<LineRenderer>();
    }

    void Update() {
        line.enabled = data.laserSight;
    }
}
