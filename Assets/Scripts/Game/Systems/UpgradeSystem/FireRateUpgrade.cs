using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/FireRateUpgrade")]
public class FireRateUpgrade : Upgrade {

    public float increaseValue;

    override protected void ApplyUpgrade() {
        playerData.fireRate += increaseValue;
    }
}
