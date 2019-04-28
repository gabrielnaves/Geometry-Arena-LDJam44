using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    public float lifetime;
    public int damage;

    Rigidbody2D body;
    Vector2 velocity;
    DestructionEffect destructionEffect;

    public void SetVelocity(Vector2 velocity) {
        this.velocity = velocity;
    }

    void Awake() {
        body = GetComponent<Rigidbody2D>();
        destructionEffect = GetComponentInChildren<DestructionEffect>();
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
        yield return new WaitForSeconds(destructionEffect.duration);
        Destroy(gameObject);
    }
}
