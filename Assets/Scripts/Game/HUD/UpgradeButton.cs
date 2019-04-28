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

    void Start() {
        ToggleButtonFlags();
    }

    void Update() {
        ToggleButtonFlags();
    }

    public void Setup(Upgrade upgrade) {
        this.upgrade = upgrade;
        title.text = upgrade.title;
        description.text = upgrade.description;
        cost.text = string.Format("costs <u>{0} health</u>", upgrade.GetCost());
        ToggleButtonFlags();
    }

    public void ApplyUpgrade() {
        button.interactable = false;
        enabled = false;
        upgrade.UseUpgrade();
    }

    void ToggleButtonFlags() {
        button.interactable = upgrade != null && playerData.health > upgrade.GetCost();
        enabled = button.interactable;
    }
}
