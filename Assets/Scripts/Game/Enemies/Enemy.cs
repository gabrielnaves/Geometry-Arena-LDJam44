﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public EnemyData data;
    public EnemyManager manager;
    public PlayerManager playerManager;
    public ObstacleManager obstacleManager;
    public WaveData waveData;

    [ViewOnly] public int health;
    [ViewOnly] public bool dead;

    Rigidbody2D body;
    DestructionEffect destructionEffect;
    Transform player;

    void Awake() {
        body = GetComponentInChildren<Rigidbody2D>();
        destructionEffect = GetComponentInChildren<DestructionEffect>();
        manager.AddEnemy(this);
        health = data.health;
    }

    void Start() {
        GetPlayer();
    }

    void GetPlayer() {
        if (playerManager.HasPlayer())
            player = playerManager.GetCurrentPlayer().transform;
    }

    void FixedUpdate() {
        if (!dead) {
            obstacleManager.ApplyRepellingForceTo(body);
            PursuePlayerIfAny();
            ApplyConstraints();
        }
    }

    void PursuePlayerIfAny() {
        if (player)
            body.AddForce((player.position - transform.position).normalized * data.pursuitForce);
    }

    void ApplyConstraints() {
        if (body.velocity.sqrMagnitude > data.maxSpeed * data.maxSpeed)
            body.velocity = body.velocity.normalized * data.maxSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(Tags.player))
            DamagePlayer(collision.gameObject.GetComponent<Player>());
    }

    void DamagePlayer(Player player) {
        player.ReceiveDamage(transform, data.damageDealt);
    }

    public void ReceiveDamage(int amount) {
        NumbersUtility.instance.CreateNumberAt(transform.position + Vector3.up, amount);
        health -= amount;
        if (health <= 0)
            Kill();
    }

    void Kill() {
        StartCoroutine(KillRoutine());
    }

    IEnumerator KillRoutine() {
        dead = true;
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<LineRenderer>().enabled = false;
        destructionEffect.Play();
        int maxLifeOrbs = waveData.currentWave / 3 + 2;
        LifeOrbUtility.instance?.CreateOrbsAt(transform.position, Random.Range(1, maxLifeOrbs));
        yield return new WaitForSeconds(destructionEffect.duration);
        Destroy(gameObject);
    }

    void OnDestroy() {
        manager.RemoveEnemy(this);
    }
}
