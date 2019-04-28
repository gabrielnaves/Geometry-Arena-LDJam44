using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour {

    public WaveData waveData;
    public List<UpgradeTier> upgradeTiers;

    CanvasGroup canvasGroup;
    CanvasGroupFader fader;
    List<UpgradeButton> buttons;
    List<Upgrade> upgrades = new List<Upgrade>();
    bool open;
    bool closed;

    void Awake() {
        buttons = new List<UpgradeButton>(GetComponentsInChildren<UpgradeButton>());
    }

    void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
        fader = GetComponent<CanvasGroupFader>();
        canvasGroup.blocksRaycasts = false;
        open = false;
        closed = true;
        UpdateUpgradeList();
    }

    void UpdateUpgradeList() {
        foreach (var tier in upgradeTiers) {
            if (tier.tierWave == waveData.currentWave)
                foreach (var upgrade in tier.upgrades)
                    upgrades.Add(upgrade);
        }
        upgrades.RemoveAll((upgrade) => upgrade.IsExpired());
        upgrades.Shuffle();
    }

    void Update() {
        if (open) {
            bool shouldClose = true;
            foreach (var button in buttons)
                shouldClose = shouldClose && !button.interactable;
            if (shouldClose) CloseMenu();
        }
    }

    public void OpenMenu() {
        canvasGroup.blocksRaycasts = true;
        UpdateUpgradeList();
        while (upgrades.Count < buttons.Count) {
            Destroy(buttons[buttons.Count - 1].gameObject);
            buttons.RemoveAt(buttons.Count-1);
        }
        for (int i = 0; i < buttons.Count; ++i)
            buttons[i].Setup(upgrades[i]);
        fader.RequestFadeIn();
        open = true;
        closed = false;
    }


    public void CloseMenu() {
        if (open)
            StartCoroutine(CloseRoutine());
    }

    IEnumerator CloseRoutine() {
        open = false;
        yield return new WaitUntil(() => fader.IsIdle());
        canvasGroup.blocksRaycasts = false;
        fader.RequestFadeOut();
        closed = true;
    }

    public bool IsClosed() {
        return closed;
    }
}

[System.Serializable]
public class UpgradeTier {
    public int tierWave;
    public Upgrade[] upgrades;
}
