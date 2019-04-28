using UnityEngine;

[CreateAssetMenu(menuName="Game/Data/PlayerData")]
public class PlayerData : ScriptableObject {

    #region Health
    public int startingHealth;
    [ViewOnly] public int health;
    [ViewOnly] public bool dead;
    public float damagedTime;
    public float blinkTime;
    #endregion

    #region Movement
    public float startingAcceleration;
    [ViewOnly] public float acceleration;
    public float startingMaxSpeed;
    [ViewOnly] public float maxSpeed;
    #endregion

    #region Shooting
    public float startingFireRate;
    [ViewOnly] public float fireRate;
    public float spread;
    public float knockback;
    public GameObject startingProjectile;
    [ViewOnly] public GameObject bullet;
    public float startingBulletSpeed;
    [ViewOnly] public float bulletSpeed;
    public int startingDamage = 1;
    [ViewOnly] public int damage;
    #endregion

    public void ReceiveHealth(int value) {
        if (!dead)
            health += value;
    }

    public void ReceiveDamage(int value) {
        health -= value;
        if (health <= 0) {
            health = 0;
            dead = true;
        }
    }

    public void Setup() {
        health = startingHealth;
        acceleration = startingAcceleration;
        maxSpeed = startingMaxSpeed;
        fireRate = startingFireRate;
        bullet = startingProjectile;
        bulletSpeed = startingBulletSpeed;
        damage = startingDamage;
    }

    public void Reset() {
        dead = false;
        health = 0;
        acceleration = 0;
        maxSpeed = 0;
        fireRate = 0;
        bullet = null;
        bulletSpeed = 0;
        damage = 0;
    }
}
