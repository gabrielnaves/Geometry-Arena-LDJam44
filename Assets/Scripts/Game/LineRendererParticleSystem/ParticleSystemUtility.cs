using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPooler))]
public class ParticleSystemUtility : MonoBehaviour {

    static public ParticleSystemUtility instance { get; private set; }

    public AnimationCurve sizeOverLifetime;

    ObjectPooler pooler;

    void Awake() {
        instance = (ParticleSystemUtility)Utility.Singleton.Setup(this, instance);
        pooler = GetComponent<ObjectPooler>();
    }

    public void ExplosionEffect(Vector3 position, MinMax velocityRange, int particleAmount, float lifetime, float size, Gradient gradient) {
        ExplosionEffect(position, velocityRange, particleAmount, lifetime, size, gradient, sizeOverLifetime);
    }

    public void ExplosionEffect(Vector3 position, MinMax velocityRange, int particleAmount, float lifetime, float size, Gradient gradient, AnimationCurve sizeOverLifetime) {
        Color color = gradient.Evaluate(Random.value);
        LineRendererParticle[] particles = new LineRendererParticle[particleAmount];
        for (int i = 0; i < particleAmount; ++i) {
            var particle = pooler.GetObject().GetComponent<LineRendererParticle>();
            particle.Activate();
            particle.size = size;
            particle.position = position;
            particle.velocity = Random.insideUnitCircle.normalized * velocityRange.Random();
            particle.color = color;
            particles[i] = particle;
        }
        StartCoroutine(UpdateParticles(particles, lifetime, size, sizeOverLifetime));
    }

    IEnumerator UpdateParticles(LineRendererParticle[] particles, float lifetime, float size, AnimationCurve sizeOverLifetime) {
        float timer = 0;
        while (timer < lifetime) {
            yield return null;
            timer += Time.deltaTime;
            foreach (var particle in particles) {
                particle.position += particle.velocity * Time.deltaTime;
                particle.size = size * sizeOverLifetime.Evaluate(timer / lifetime);
            }
        }
        for (int i = 0; i < particles.Length; ++i)
            pooler.ReturnObject(particles[i].gameObject);
    }
}
