using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthMeter : MonoBehaviour {

    public PlayerData playerData;
    public TextMeshProUGUI text;

    void Update() {
        text.text = "health: " + playerData.health;
    }
}
