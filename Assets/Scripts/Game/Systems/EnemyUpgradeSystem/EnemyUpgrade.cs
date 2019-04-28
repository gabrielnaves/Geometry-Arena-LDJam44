using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyUpgrade : ScriptableObject {

    public string title;
    public bool limited;
    public int maxUses;
    public EnemyData[] data;

    [System.NonSerialized] int timesUsed = 0;

    public bool IsExpired() {
        return limited && timesUsed == maxUses;
    }

    public void UseUpgrade() {
        timesUsed++;
        foreach (var enemy in data)
            ApplyUpgrade(enemy);
    }

    abstract protected void ApplyUpgrade(EnemyData enemy);
}
