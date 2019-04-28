using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Data/WaveData")]
public class WaveData : ScriptableObject {

    [ViewOnly] public int currentWave;
    public float spawnDelay;
    public EnemyWaveInfo[] enemies = new EnemyWaveInfo[0];

    public void Reset() {
        currentWave = 0;
    }

    public GameObject[] GetEnemiesToGenerate() {
        List<GameObject> enemiesToGenerate = new List<GameObject>();
        foreach (var enemyInfo in enemies) {
            if (currentWave >= enemyInfo.minWave) {
                for (int i = 0; i < enemyInfo.GetEnemyAmount(); ++i)
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

    [System.NonSerialized] int enemyAmount = 0;

    public int GetEnemyAmount() {
        if (enemyAmount == 0)
            enemyAmount = startingEnemyAmount;
        return enemyAmount;
    }

    public void IncreaseEnemyAmount() {
        enemyAmount += Mathf.RoundToInt(amountIncreaseRange.Random());
    }
}
