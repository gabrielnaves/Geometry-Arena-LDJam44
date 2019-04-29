using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionEffect : MonoBehaviour {

    public MinMax velocity;
    public int particles;
    public float lifetime;
    public float size;
    public Gradient gradient;

    public float duration { get { return lifetime; } }

    public void Play() {
        ParticleSystemUtility.instance.ExplosionEffect(transform.position, velocity, particles, lifetime, size, gradient);
    }
}
