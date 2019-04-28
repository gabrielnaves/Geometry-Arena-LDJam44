using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour {

    public List<Upgrade> upgrades;

    CanvasGroup canvasGroup;
    CanvasGroupFader fader;
    List<UpgradeButton> buttons;

    void Awake() {
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
        canvasGroup.blocksRaycasts = false;
        fader.RequestFadeOut();
        enabled = false;
    }

    public bool IsOpen() {
        return enabled;
    }
}
