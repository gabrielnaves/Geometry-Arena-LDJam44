using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/BulletSpeedUpgrade")]
public class BulletSpeedUpgrade : Upgrade {

    public float increaseValue;

    override protected void ApplyUpgrade() {
        playerData.bulletSpeed += increaseValue;
    }
}
