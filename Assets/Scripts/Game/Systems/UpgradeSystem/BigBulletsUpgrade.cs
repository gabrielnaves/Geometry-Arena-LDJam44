using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/BigBulletsUpgrade")]
public class BigBulletsUpgrade : Upgrade {

    override protected void ApplyUpgrade() {
        playerData.bigBullets = true;
    }
}
