using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

    public float lifetime;

    Rigidbody2D body;
    Vector2 velocity;
    ParticleSystem destructionEffect;

    public void SetVelocity(Vector2 velocity) {
        this.velocity = velocity;
    }

    void Awake() {
        body = GetComponent<Rigidbody2D>();
        destructionEffect = GetComponentInChildren<ParticleSystem>();
        destructionEffect.Stop();
    }

    void Start() {
        body.velocity = velocity;
        StartCoroutine(LifetimeRoutine());
    }

    IEnumerator LifetimeRoutine() {
        yield return new WaitForSeconds(lifetime);
        Kill();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Kill();
    }

    void Kill() {
        StartCoroutine(KillRoutine());
    }

    IEnumerator KillRoutine() {
        body.velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<LineRenderer>().enabled = false;
        destructionEffect.Play();
        yield return new WaitForSeconds(destructionEffect.main.startLifetime.constant);
        Destroy(gameObject);
    }
}
