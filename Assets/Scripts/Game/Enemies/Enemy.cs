using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public EnemyData data;
    public PlayerManager playerManager;

    [ViewOnly] public bool dead;

    Rigidbody2D body;
    DestructionEffect destructionEffect;
    Transform player;

    void Awake() {
        body = GetComponentInChildren<Rigidbody2D>();
        destructionEffect = GetComponentInChildren<DestructionEffect>();
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
        if (collision.gameObject.CompareTag(Tags.bullet))
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
        yield return new WaitForSeconds(destructionEffect.duration);
        Destroy(gameObject);
    }
}
