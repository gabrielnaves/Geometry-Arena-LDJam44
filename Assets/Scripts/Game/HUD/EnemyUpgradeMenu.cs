using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyUpgradeMenu : MonoBehaviour {

    public List<EnemyUpgrade> upgrades;

    public TextMeshProUGUI upgradeText;

    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void ShowEnemyUpgrade() {
        upgrades.RemoveAll((upgrade) => upgrade.IsExpired());
        upgrades.Shuffle();
        upgradeText.text = upgrades[0].title;
        animator.SetTrigger("Show");
        upgrades[0].UseUpgrade();
    }

    public bool Hidden() {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Hidden");
    }
}
