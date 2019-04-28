using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingControls : MonoBehaviour {

    public PlayerData data;
    public InputData input;
    public Transform bulletPos;

    Rigidbody2D body;
    bool cooldown;
    float cooldownTimer;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

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
        float angle = Mathf.Atan2(transform.right.y, transform.right.x);

        if (!data.laserSight) {
            float maxSpreadAngle = Mathf.Clamp(data.fireRate * data.spread, 0, 30);
            float spreadAngle = Random.Range(-maxSpreadAngle, maxSpreadAngle) * Mathf.Deg2Rad;
            angle += spreadAngle;
        }

        Vector2 velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * data.bulletSpeed;
        bullet.SetVelocity(velocity);
        bullet.damage = data.damage;
    }
}
