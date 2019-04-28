using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/MaxSpeedUpgrade")]
public class MaxSpeedUpgrade : Upgrade {

    public PlayerData playerData;
    public float increaseValue;

    override public void ApplyUpgrade() {
        playerData.maxSpeed += increaseValue;
    }
}
