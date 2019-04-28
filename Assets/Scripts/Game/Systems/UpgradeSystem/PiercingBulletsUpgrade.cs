using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Upgrades/PiercingBulletsUpgrade")]
public class PiercingBulletsUpgrade : Upgrade {

    override protected void ApplyUpgrade() {
        playerData.piercingBullets = true;
    }
}
