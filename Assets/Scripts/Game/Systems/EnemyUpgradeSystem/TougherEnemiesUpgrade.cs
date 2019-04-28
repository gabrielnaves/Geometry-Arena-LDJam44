using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/EnemyUpgrades/TougherEnemies")]
public class TougherEnemiesUpgrade : EnemyUpgrade {

    public int increaseValue;

    override protected void ApplyUpgrade(EnemyData enemy) {
        enemy.health += increaseValue;
    }
}
