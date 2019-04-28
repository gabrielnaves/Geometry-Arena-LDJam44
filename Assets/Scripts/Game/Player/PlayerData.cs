using UnityEngine;

[CreateAssetMenu(menuName="Game/Data/PlayerData")]
public class PlayerData : ScriptableObject {

    #region Health
    public int startingHealth;
    [ViewOnly] public int health;
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
    public GameObject startingProjectile;
    [ViewOnly] public GameObject bullet;
    public float startingBulletSpeed;
    [ViewOnly] public float bulletSpeed;
    #endregion

    public void Setup() {
        health = startingHealth;
        acceleration = startingAcceleration;
        maxSpeed = startingMaxSpeed;
        fireRate = startingFireRate;
        bullet = startingProjectile;
        bulletSpeed = startingBulletSpeed;
    }

    public void Reset() {
        health = 0;
        acceleration = 0;
        maxSpeed = 0;
        fireRate = 0;
        bullet = null;
        bulletSpeed = 0;
    }
}
