using UnityEngine;

[CreateAssetMenu(menuName="Game/Data/EnemyData")]
public class EnemyData : ScriptableObject {

    public int startingHealth = 1;
    [ViewOnly] public int health;
    public float startingPursuitForce;
    public float maxPursuitForce;
    [ViewOnly] public float pursuitForce;
    public float startingMaxSpeed;
    [ViewOnly] public float maxSpeed;
    public int startingDamageDealt = 3;
    [ViewOnly] public int damageDealt;

    public void Setup() {
        health = startingHealth;
        pursuitForce = startingPursuitForce;
        maxSpeed = startingMaxSpeed;
        damageDealt = startingDamageDealt;
    }

    public void Reset() {
        health = 0;
        pursuitForce = 0;
        maxSpeed = 0;
        damageDealt = 0;
    }
}
