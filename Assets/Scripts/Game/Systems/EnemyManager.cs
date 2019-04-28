using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Systems/EnemyManager")]
public class EnemyManager : ScriptableObject {

    [System.NonSerialized] List<Enemy> enemies = new List<Enemy>();

    public void AddEnemy(Enemy enemy) {
        if (!enemies.Contains(enemy))
            enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy) {
        if (enemies.Contains(enemy))
            enemies.Remove(enemy);
    }

    public bool HasEnemy() {
        return enemies.Count > 0;
    }
}
