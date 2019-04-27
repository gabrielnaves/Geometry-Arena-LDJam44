using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public ObstacleManager obstacleManager;
    public float closenessRadius = 1;
    public MinMax repellingForce;

    void Awake() {
        obstacleManager.AddObstacle(this);
    }

    void OnDestroy() {
        obstacleManager.AddObstacle(this);
    }

    public void ApplyRepellingForceTo(Rigidbody2D body) {
        Vector2 distVector = body.position - (Vector2)transform.position;
        if (distVector.sqrMagnitude <= closenessRadius * closenessRadius) {
            float force = repellingForce.ReverseLerp(distVector.magnitude / closenessRadius);
            body.AddForce(distVector.normalized * force);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closenessRadius);
    }
}
