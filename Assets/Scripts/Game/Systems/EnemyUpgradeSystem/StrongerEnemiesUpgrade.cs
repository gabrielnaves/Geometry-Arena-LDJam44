using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/EnemyUpgrades/StrongerEnemies")]
public class StrongerEnemiesUpgrade : EnemyUpgrade {

    public int increaseValue;

    override protected void ApplyUpgrade(EnemyData enemy) {
        enemy.damageDealt += increaseValue;
    }
}
