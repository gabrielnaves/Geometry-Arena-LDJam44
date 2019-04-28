using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroupFader))]
public class GameMenu : MonoBehaviour {

    static public GameMenu instance { get; private set; }

    public float delay = 1;

    CanvasGroupFader fader;

    void Awake() {
        instance = (GameMenu)Utility.Singleton.Setup(this, instance);
        fader = GetComponent<CanvasGroupFader>();
    }

    void Update() {
        if (Time.timeSinceLevelLoad > delay && Input.anyKeyDown)
            Close();
    }

    void Close() {
        enabled = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        fader.RequestFadeOut();
    }

    public bool IsClosed() {
        return !enabled;
    }
}
