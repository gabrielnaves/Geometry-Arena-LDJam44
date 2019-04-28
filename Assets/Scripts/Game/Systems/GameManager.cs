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
        if (WaveEnded() && !IntermissionMenus.instance.IsOpen())
            StartCoroutine(ShowUpgradeMenuRoutine());
    }

    bool WaveEnded() {
        return !enemyManager.HasEnemy();
    }

    IEnumerator ShowUpgradeMenuRoutine() {
        IntermissionMenus.instance.ShowIntermissionMenu();
        yield return new WaitUntil(() => !IntermissionMenus.instance.IsOpen());
        waveManager.StartNextWave();
    }
}
