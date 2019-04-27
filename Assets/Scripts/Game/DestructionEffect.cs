using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionEffect : MonoBehaviour {

    ParticleSystem effect;

    public float duration { get { return effect.main.startLifetime.constant; } }

    void Awake() {
        effect = GetComponent<ParticleSystem>();
        effect.Stop();
    }

    public void Play() {
        effect.Play();
    }
}
