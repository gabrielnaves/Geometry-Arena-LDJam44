using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPooler))]
public class ParticleSystemUtility : MonoBehaviour {

    static public ParticleSystemUtility instance { get; private set; }

    ObjectPooler pooler;

    void Awake() {
        instance = (ParticleSystemUtility)Utility.Singleton.Setup(this, instance);
        pooler = GetComponent<ObjectPooler>();
    }

    public void ExplosionEffect(Vector3 position, MinMax velocityRange, int particleAmount, float lifetime, float size, Gradient gradient) {
        LineRendererParticle[] particles = new LineRendererParticle[particleAmount];
        for (int i = 0; i < particleAmount; ++i) {
            var particle = pooler.GetObject().GetComponent<LineRendererParticle>();
            particle.Activate();
            particle.size = size;
            particle.position = position;
            particle.velocity = Random.insideUnitCircle.normalized * velocityRange.Random();
            particle.color = gradient.Evaluate(Random.value);
            particles[i] = particle;
        }
        StartCoroutine(UpdateParticles(particles, lifetime));
    }

    IEnumerator UpdateParticles(LineRendererParticle[] particles, float lifetime) {
        float timer = 0;
        while (timer < lifetime) {
            yield return null;
            timer += Time.deltaTime;
            foreach (var particle in particles)
                particle.position += particle.velocity * Time.deltaTime;
        }
        for (int i = 0; i < particles.Length; ++i)
            pooler.ReturnObject(particles[i].gameObject);
    }
}
