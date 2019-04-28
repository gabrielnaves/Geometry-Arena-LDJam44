using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Data/WaveData")]
public class WaveData : ScriptableObject {

    [ViewOnly] public int currentWave;
    public float spawnDelay;
    public EnemyWaveInfo[] enemies = new EnemyWaveInfo[0];

    public void Setup() {
        foreach (var enemy in enemies)
            enemy.Setup();
    }

    public void Reset() {
        currentWave = 0;
        foreach (var enemy in enemies)
            enemy.Reset();
    }

    public GameObject[] GetEnemiesToGenerate() {
        List<GameObject> enemiesToGenerate = new List<GameObject>();
        foreach (var enemyInfo in enemies) {
            if (currentWave >= enemyInfo.minWave) {
                for (int i = 0; i < enemyInfo.enemyAmount; ++i)
                    enemiesToGenerate.Add(enemyInfo.prefab);
            }
        }
        enemiesToGenerate.Shuffle();
        return enemiesToGenerate.ToArray();
    }

    public void IncreaseEnemyAmount() {
        foreach (var enemyInfo in enemies)
            enemyInfo.IncreaseEnemyAmount();
    }
}

[System.Serializable]
public class EnemyWaveInfo {
    public GameObject prefab;
    public int minWave;
    public int startingEnemyAmount;
    public MinMax amountIncreaseRange;

    [ViewOnly] public int enemyAmount = 0;

    public void Setup() {
        enemyAmount = startingEnemyAmount;
    }

    public void Reset() {
        enemyAmount = 0;
    }

    public void IncreaseEnemyAmount() {
        enemyAmount += Mathf.RoundToInt(amountIncreaseRange.Random());
    }
}
