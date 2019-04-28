using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/BulletSpeedUpgrade")]
public class BulletSpeedUpgrade : Upgrade {

    public PlayerData playerData;
    public float increaseValue;

    override public void ApplyUpgrade() {
        playerData.bulletSpeed += increaseValue;
    }
}
