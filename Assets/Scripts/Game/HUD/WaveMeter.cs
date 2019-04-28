using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveMeter : MonoBehaviour {

    public WaveData WaveData;
    public TextMeshProUGUI text;

    void Update() {
        text.text = "wave: " + WaveData.currentWave;
    }
}
