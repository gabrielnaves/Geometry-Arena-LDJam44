using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/DamageUpgrade")]
public class DamageUpgrade : Upgrade {

    public int increaseValue;

    override protected void ApplyUpgrade() {
        playerData.damage += increaseValue;
    }
}
