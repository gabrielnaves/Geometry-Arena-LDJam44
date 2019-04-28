using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/EnemyUpgrades/FasterEnemies")]
public class FasterEnemiesUpgrade : EnemyUpgrade {

    public float maxSpeedIncrease;
    public float pursuitForceIncrease;

    override protected void ApplyUpgrade(EnemyData enemy) {
        enemy.maxSpeed += maxSpeedIncrease;
        enemy.pursuitForce += pursuitForceIncrease;
        if (enemy.pursuitForce > enemy.maxPursuitForce)
            enemy.pursuitForce = enemy.maxPursuitForce;
    }
}
