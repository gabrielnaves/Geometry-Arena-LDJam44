using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public PlayerManager playerManager;

    Rigidbody2D body;
    DestructionEffect destructionEffect;

    void Awake() {
        body = GetComponentInChildren<Rigidbody2D>();
        destructionEffect = GetComponentInChildren<DestructionEffect>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(Tags.bullet))
            Kill();
    }

    void Kill() {
        StartCoroutine(KillRoutine());
    }

    IEnumerator KillRoutine() {
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<LineRenderer>().enabled = false;
        destructionEffect.Play();
        yield return new WaitForSeconds(destructionEffect.duration);
        Destroy(gameObject);
    }
}
