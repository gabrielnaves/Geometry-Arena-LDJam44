using UnityEngine;

[CreateAssetMenu(menuName="Game/Data/EnemyData")]
public class EnemyData : ScriptableObject {

    public float startingPursuitForce;
    [ViewOnly] public float pursuitForce;
    public float startingMaxSpeed;
    [ViewOnly] public float maxSpeed;

    public void Setup() {
        pursuitForce = startingPursuitForce;
        maxSpeed = startingMaxSpeed;
    }

    public void Reset() {
        pursuitForce = 0;
        maxSpeed = 0;
    }
}
