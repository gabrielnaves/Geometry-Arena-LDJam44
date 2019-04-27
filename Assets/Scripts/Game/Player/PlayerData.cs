using UnityEngine;

[CreateAssetMenu(menuName="Game/Data/PlayerData")]
public class PlayerData : ScriptableObject {

    #region Movement
    public float startingAcceleration;
    [ViewOnly] public float acceleration;
    public float startingMaxSpeed;
    [ViewOnly] public float maxSpeed;
    #endregion

    #region Shooting
    public float startingShootCooldown;
    [ViewOnly] public float shootCooldown;
    public GameObject startingProjectile;
    [ViewOnly] public GameObject bullet;
    public float startingBulletSpeed;
    [ViewOnly] public float bulletSpeed;
    #endregion

    public void Setup() {
        acceleration = startingAcceleration;
        maxSpeed = startingMaxSpeed;
        shootCooldown = startingShootCooldown;
        bullet = startingProjectile;
        bulletSpeed = startingBulletSpeed;
    }

    public void Reset() {
        acceleration = 0;
        maxSpeed = 0;
        shootCooldown = 0;
        bullet = null;
        bulletSpeed = 0;
    }
}
