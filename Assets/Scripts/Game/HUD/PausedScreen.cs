using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedScreen : MonoBehaviour {

    static public PausedScreen instance { get; private set; }

    void Awake() {
        instance = (PausedScreen)Utility.Singleton.Setup(this, instance);
        GetComponent<CanvasGroup>().alpha = 1;
    }

    void Start() {
        gameObject.SetActive(false);
    }
}
