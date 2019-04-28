using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/LaserSightUpgrade")]
public class LaserSightUpgrade : Upgrade {

    override protected void ApplyUpgrade() {
        playerData.laserSight = true;
    }
}
