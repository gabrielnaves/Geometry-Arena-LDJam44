using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingControls : MonoBehaviour {

    public PlayerData data;
    public InputData input;
    public Transform projectilePoint;

    bool cooldown;
    float cooldownTimer;

    void Update() {
        if (cooldown) {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer > data.shootCooldown)
                cooldown = false;
        }
        if (!cooldown && input.action) {
            Shoot();
            cooldown = true;
            cooldownTimer = 0;
        }
    }

    void Shoot() {
        var projectile = Instantiate(data.projectile, projectilePoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetVelocity(transform.right * data.projectileSpeed);
    }
}
