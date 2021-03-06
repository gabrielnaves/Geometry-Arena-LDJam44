using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/MaxSpeedUpgrade")]
public class MaxSpeedUpgrade : Upgrade {

    public float increaseValue;

    override protected void ApplyUpgrade() {
        playerData.maxSpeed += increaseValue;
    }
}
