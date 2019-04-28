using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour {

    static public UpgradeMenu instance { get; private set; }

    public Upgrade[] upgrades;

    CanvasGroup canvasGroup;
    CanvasGroupFader fader;
    UpgradeButton[] buttons;

    void Awake() {
        instance = (UpgradeMenu)Utility.Singleton.Setup(this, instance);
        buttons = GetComponentsInChildren<UpgradeButton>();
    }

    void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
        fader = GetComponent<CanvasGroupFader>();
        canvasGroup.blocksRaycasts = false;
        enabled = false;
    }

    void Update() {
        bool shouldClose = true;
        foreach (var button in buttons)
            shouldClose = shouldClose && !button.interactable;
        if (shouldClose) CloseMenu();
    }

    public void OpenMenu() {
        InputManager.instance.enabled = false;
        canvasGroup.blocksRaycasts = true;
        upgrades.Shuffle();
        for (int i = 0; i < buttons.Length; ++i)
            buttons[i].Setup(upgrades[i]);
        fader.RequestFadeIn();
        enabled = true;
    }

    public void CloseMenu() {
        InputManager.instance.enabled = true;
        canvasGroup.blocksRaycasts = false;
        fader.RequestFadeOut();
        enabled = false;
    }

    public bool IsOpen() {
        return enabled;
    }
}
