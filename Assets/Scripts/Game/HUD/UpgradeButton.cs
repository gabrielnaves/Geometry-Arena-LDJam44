using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour {

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI cost;
    public PlayerData playerData;

    Button button;
    Upgrade upgrade;

    public bool interactable { get { return button.interactable; } }

    void Awake() {
        button = GetComponent<Button>();
    }

    public void Setup(Upgrade upgrade) {
        this.upgrade = upgrade;
        title.text = upgrade.title;
        description.text = upgrade.description;
        cost.text = string.Format("costs <u>{0} health</u>", upgrade.cost);
        button.interactable = playerData.health > upgrade.cost;
    }

    public void ApplyUpgrade() {
        button.interactable = false;
        playerData.health -= upgrade.cost;
        upgrade.ApplyUpgrade();
    }
}
