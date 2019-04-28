using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    public float lifetime;
    public int damage;
    public bool piercing;

    Rigidbody2D body;
    Collider2D col;
    Vector2 velocity;
    DestructionEffect destructionEffect;

    public void SetVelocity(Vector2 velocity) {
        this.velocity = velocity;
    }

    void Awake() {
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        destructionEffect = GetComponentInChildren<DestructionEffect>();
    }

    void Start() {
        if (piercing) col.isTrigger = true;

        body.velocity = velocity;
        StartCoroutine(LifetimeRoutine());
    }

    IEnumerator LifetimeRoutine() {
        yield return new WaitForSeconds(lifetime);
        Kill();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag(Tags.enemy))
            other.gameObject.GetComponent<Enemy>().ReceiveDamage(damage);
        Kill();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(Tags.enemy))
            other.GetComponent<Enemy>().ReceiveDamage(damage);
        else if (other.CompareTag(Tags.scenario))
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
