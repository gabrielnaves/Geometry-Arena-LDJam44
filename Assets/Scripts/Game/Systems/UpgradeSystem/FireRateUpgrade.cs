using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/FireRateUpgrade")]
public class FireRateUpgrade : Upgrade {

    public PlayerData playerData;
    public float increaseValue;

    override public void ApplyUpgrade() {
        playerData.fireRate += increaseValue;
    }
}
