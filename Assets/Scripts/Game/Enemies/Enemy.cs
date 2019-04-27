using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody2D body;
    DestructionEffect destructionEffect;

    void Awake() {
        body = GetComponentInChildren<Rigidbody2D>();
        destructionEffect = GetComponentInChildren<DestructionEffect>();
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
