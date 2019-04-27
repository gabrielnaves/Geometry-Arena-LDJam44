using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingControls : MonoBehaviour {

    public PlayerData data;
    public InputData input;
    public Transform bulletPos;

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
        var bullet = Instantiate(data.bullet, bulletPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetVelocity(transform.right * data.bulletSpeed);
    }
}
