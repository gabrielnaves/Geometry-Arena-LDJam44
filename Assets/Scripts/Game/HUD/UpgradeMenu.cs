using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour {

    static public UpgradeMenu instance { get; private set; }

    public List<Upgrade> upgrades;

    CanvasGroup canvasGroup;
    CanvasGroupFader fader;
    List<UpgradeButton> buttons;

    void Awake() {
        instance = (UpgradeMenu)Utility.Singleton.Setup(this, instance);
        buttons = new List<UpgradeButton>(GetComponentsInChildren<UpgradeButton>());
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
        upgrades.RemoveAll((upgrade) => upgrade.IsExpired());
        upgrades.Shuffle();
        while (upgrades.Count < buttons.Count) {
            Destroy(buttons[buttons.Count - 1].gameObject);
            buttons.RemoveAt(buttons.Count-1);
        }
        for (int i = 0; i < buttons.Count; ++i)
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
