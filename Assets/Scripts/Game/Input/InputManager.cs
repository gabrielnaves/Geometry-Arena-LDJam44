using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    static public InputManager instance { get; private set; }

    public InputData input;

    void Awake() {
        instance = (InputManager)Utility.Singleton.Setup(this, instance);
    }

    void Update() {
        input.boost = Input.GetKey(KeyCode.Space);
        input.boostDown = Input.GetKeyDown(KeyCode.Space);
        input.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        input.action = Input.GetMouseButton(0);
        input.actionDown = Input.GetMouseButtonDown(0);
        input.actionUp = Input.GetMouseButtonUp(0);
    }

    void OnDisable() {
        input.boost = false;
        input.boostDown = false;
        input.action = false;
        input.actionDown = false;
        input.actionUp = false;
    }
}
