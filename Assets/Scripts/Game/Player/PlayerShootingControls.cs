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
            if (cooldownTimer > 1 / data.fireRate)
                cooldown = false;
        }
        if (!cooldown && input.action) {
            Shoot();
            cooldown = true;
            cooldownTimer = 0;
        }
    }

    void Shoot() {
        var bulletObj = Instantiate(data.bullet, bulletPos.position, Quaternion.identity);
        var bullet = bulletObj.GetComponent<Bullet>();
        bullet.SetVelocity(transform.right * data.bulletSpeed);
        bullet.damage = 1;
    }
}
