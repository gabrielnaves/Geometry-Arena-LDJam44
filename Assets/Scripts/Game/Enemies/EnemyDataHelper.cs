using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataHelper : MonoBehaviour {

    public EnemyData[] enemyDataList;

    void Awake() {
        foreach (var data in enemyDataList)
            data.Setup();
    }

    void OnDestroy() {
        foreach (var data in enemyDataList)
            data.Reset();
    }
}
