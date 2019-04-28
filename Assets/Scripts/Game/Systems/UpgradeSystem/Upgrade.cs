using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Upgrade : ScriptableObject {

    public string title;
    public string description;
    public int startingCost;
    public int costIncreasePerUse;
    public bool limited;
    public int maxUses;
    public PlayerData playerData;

    [System.NonSerialized] int cost = 0;
    [System.NonSerialized] int timesUsed = 0;

    public int GetCost() {
        if (cost == 0) cost = startingCost;
        return cost;
    }

    public bool IsExpired() {
        return limited && timesUsed == maxUses;
    }

    public void UseUpgrade() {
        playerData.health -= cost;
        timesUsed++;
        cost += costIncreasePerUse;
        ApplyUpgrade();
    }

    abstract protected void ApplyUpgrade();
}
