using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyUpgradeMenu : MonoBehaviour {

    public WaveData waveData;
    public TextMeshProUGUI upgradeText;
    public List<EnemyUpgrade> upgrades;

    Animator animator;
    int upgradeAmount;
    bool isDone;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void ShowEnemyUpgrade() {
        StartCoroutine(ShowEnemyUpgradesRoutine());
    }

    IEnumerator ShowEnemyUpgradesRoutine() {
        isDone = false;
        upgradeAmount = (waveData.currentWave / 5) + 1;
        for (int i = 0; i < upgradeAmount; ++i) {
            upgrades.RemoveAll((upgrade) => upgrade.IsExpired());
            int index = Random.Range(0, upgrades.Count);
            upgradeText.text = upgrades[index].title;
            upgrades[index].UseUpgrade();
            animator.SetTrigger("Show");
            yield return null;
            yield return new WaitUntil(() => Hidden());
        }
        isDone = true;
    }

    bool Hidden() {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Hidden");
    }

    public bool IsDone() {
        return isDone;
    }
}
