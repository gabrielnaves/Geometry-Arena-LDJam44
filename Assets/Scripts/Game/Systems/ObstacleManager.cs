using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Systems/ObstacleManager")]
public class ObstacleManager : ScriptableObject {

    [System.NonSerialized] List<Obstacle> obstacles = new List<Obstacle>();

    public void AddObstacle(Obstacle obstacle) {
        if (!obstacles.Contains(obstacle))
            obstacles.Add(obstacle);
    }

    public void RemoveObstacle(Obstacle obstacle) {
        if (obstacles.Contains(obstacle))
            obstacles.Remove(obstacle);
    }

    public void ApplyRepellingForceTo(Rigidbody2D body) {
        foreach (var obstacle in obstacles)
            obstacle.ApplyRepellingForceTo(body);
    }
}
