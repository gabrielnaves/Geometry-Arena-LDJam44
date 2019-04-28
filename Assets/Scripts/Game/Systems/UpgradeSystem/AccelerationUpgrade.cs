using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/AccelerationUpgrade")]
public class AccelerationUpgrade : Upgrade {

    public float increaseValue;

    override protected void ApplyUpgrade() {
        playerData.acceleration += increaseValue;
    }
}
