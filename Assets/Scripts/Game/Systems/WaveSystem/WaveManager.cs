using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public WaveData waveData;
    public EnemyManager enemyManager;

    Utility.RectRandom rect;

    void Awake() {
        rect = GetComponent<Utility.RectRandom>();
        waveData.Reset();
    }

    void Start() {
        StartNextWave();
    }

    void StartNextWave() {
        waveData.currentWave++;
        StartCoroutine(WaveSpawnRoutine());
    }

    IEnumerator WaveSpawnRoutine() {
        GameObject[] enemies = waveData.GetEnemiesToGenerate();
        foreach (var enemy in enemies) {
            Vector3 pos = rect.RandomPointInBounds();
            Instantiate(enemy, pos, Quaternion.identity, EnemyContainer.instance?.transform);
            yield return new WaitForSeconds(waveData.spawnDelay);
        }
        waveData.IncreaseEnemyAmount();
    }

    void Update() {
        if (WaveEnded())
            StartNextWave();
    }

    bool WaveEnded() {
        return !enemyManager.HasEnemy();
    }

    void OnDestroy() {
        waveData.Reset();
    }
}
