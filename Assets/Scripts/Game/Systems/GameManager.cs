using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaveManager))]
public class GameManager : MonoBehaviour {

    public EnemyManager enemyManager;

    WaveManager waveManager;

    void Awake() {
        waveManager = GetComponent<WaveManager>();
    }

    void Start() {
        waveManager.StartNextWave();
    }

    void Update() {
        if (WaveEnded() && !UpgradeMenu.instance.IsOpen())
            StartCoroutine(ShowUpgradeMenuRoutine());
    }

    bool WaveEnded() {
        return !enemyManager.HasEnemy();
    }

    IEnumerator ShowUpgradeMenuRoutine() {
        UpgradeMenu.instance.OpenMenu();
        yield return new WaitUntil(() => !UpgradeMenu.instance.IsOpen());
        waveManager.StartNextWave();
    }
}
