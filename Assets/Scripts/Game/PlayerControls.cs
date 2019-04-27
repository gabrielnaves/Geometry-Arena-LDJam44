using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour {

    public PlayerData data;
    public InputData input;

    Rigidbody2D body;

    void Awake() {
        data.Setup();
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        LookAtMousePosition();
        MoveIfRequested();
        ApplyConstraints();
    }

    void LookAtMousePosition() {
        Vector3 direction = input.mousePosition - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }

    void MoveIfRequested() {
        if (input.boost)
            body.AddForce(transform.right * data.acceleration);
    }

    void ApplyConstraints() {
        if (body.velocity.sqrMagnitude > data.maxSpeed * data.maxSpeed)
            body.velocity = body.velocity.normalized * data.maxSpeed;
    }

    void OnDestroy() {
        data.Reset();
    }
}
