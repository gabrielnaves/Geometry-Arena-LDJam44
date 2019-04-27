using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public InputData input;

    void Update() {
        input.boost = Input.GetKey(KeyCode.Space);
        input.boostDown = Input.GetKeyDown(KeyCode.Space);
        input.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
