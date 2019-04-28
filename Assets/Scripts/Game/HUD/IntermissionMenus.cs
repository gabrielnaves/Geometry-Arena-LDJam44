using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroupFader))]
[RequireComponent(typeof(CanvasGroup))]
public class IntermissionMenus : MonoBehaviour {

    static public IntermissionMenus instance { get; private set; }

    public GameObject[] children;
    public UpgradeMenu upgradeMenu;
    public EnemyUpgradeMenu enemyUpgradeMenu;

    CanvasGroupFader fader;
    CanvasGroup canvasGroup;
    bool open;

    void Awake() {
        instance = (IntermissionMenus)Utility.Singleton.Setup(this, instance);
        fader = GetComponent<CanvasGroupFader>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
        foreach (var child in children)
            child.SetActive(true);
    }

    public void ShowIntermissionMenu() {
        StartCoroutine(IntermissionMenuRoutine());
    }

    IEnumerator IntermissionMenuRoutine() {
        // Setup
        open = true;
        InputManager.instance.enabled = false;
        canvasGroup.blocksRaycasts = true;
        fader.RequestFadeIn();
        // Player upgrades
        upgradeMenu.OpenMenu();
        yield return new WaitUntil(() => !upgradeMenu.IsOpen());
        // Enemy upgrades
        enemyUpgradeMenu.ShowEnemyUpgrade();
        yield return null;
        yield return new WaitUntil(() => enemyUpgradeMenu.Hidden());
        // End
        canvasGroup.blocksRaycasts = false;
        fader.RequestFadeOut();
        InputManager.instance.enabled = true;
        open = false;
    }

    public bool IsOpen() {
        return open;
    }
}
