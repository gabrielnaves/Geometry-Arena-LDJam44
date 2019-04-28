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
        float maxSpreadAngle = Mathf.Clamp(data.fireRate * data.spread, 0, 30);
        float spreadAngle = Random.Range(-maxSpreadAngle, maxSpreadAngle) * Mathf.Deg2Rad;
        float angle = Mathf.Atan2(transform.right.y, transform.right.x) + spreadAngle;
        bullet.SetVelocity(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * data.bulletSpeed);
        bullet.damage = data.damage;
    }
}
