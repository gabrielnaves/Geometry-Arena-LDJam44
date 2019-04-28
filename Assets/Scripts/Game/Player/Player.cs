using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerData data;
    public PlayerManager playerManager;
    [ViewOnly] public bool damaged;

    public Vector3 position { get { return transform.position; } }

    PlayerMovement playerMovement;
    PlayerShootingControls shootControls;
    PlayerLaserSight laserSight;
    DestructionEffect destructionEffect;
    Rigidbody2D body;
    LineRenderer line;
    float damagedTimer;
    float blinkTimer;

    void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        shootControls = GetComponent<PlayerShootingControls>();
        laserSight = GetComponentInChildren<PlayerLaserSight>();
        destructionEffect = GetComponentInChildren<DestructionEffect>();
        body = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
        playerManager.AddPlayer(this);
    }

    void OnDestroy() {
        playerManager.RemovePlayer(this);
    }

    public void ReceiveDamage(Transform source, int damage) {
        if (!damaged && !data.dead) {
            damaged = true;
            data.ReceiveDamage(damage);
            NumbersUtility.instance.CreateNumberAt(transform.position + Vector3.up, damage);
            if (!data.dead)
                body.velocity = (transform.position - source.position).normalized * data.maxSpeed;
            else
                StartCoroutine(DeathRoutine());
        }
    }

    IEnumerator DeathRoutine() {
        playerMovement.enabled = false;
        shootControls.enabled = false;
        laserSight.gameObject.SetActive(false);
        line.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
        destructionEffect.Play();
        yield return new WaitForSeconds(destructionEffect.duration);
        Destroy(gameObject);
    }

    void Update() {
        if (damaged && !data.dead) {
            damagedTimer += Time.deltaTime;
            blinkTimer += Time.deltaTime;
            if (blinkTimer > data.blinkTime) {
                blinkTimer -= data.blinkTime;
                line.enabled = !line.enabled;
            }
            if (damagedTimer >= data.damagedTime) {
                damaged = false;
                line.enabled = true;
                damagedTimer = 0;
                blinkTimer = 0;
            }
        }
    }
}
