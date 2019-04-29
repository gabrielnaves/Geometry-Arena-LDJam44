using System.Collections.Generic;
using UnityEngine;

// Original by Dano Kablamo (video tutorial at https://www.youtube.com/watch?v=GqHFGMy_51c)
// Additional functionality by Gabriel Naves
[RequireComponent(typeof(AudioSource))]
public class Oscillator : MonoBehaviour {

    public enum WaveType { sine, square, triangle, sawtooth }

    public WaveType waveType;
    public double frequency = 440.0;
    public float volume;

    double increment;
    double phase;
    double gain;
    double sampling_frequency = 48000.0;

    float pi_twice = Mathf.PI * 2;

    Dictionary<WaveType, System.Func<float>> waveFunction;
    float randomValue;

    void Start() {
        waveFunction = new Dictionary<WaveType, System.Func<float>>();
        waveFunction.Add(WaveType.sine, SineWave);
        waveFunction.Add(WaveType.square, SquareWave);
        waveFunction.Add(WaveType.triangle, TriangleWave);
        waveFunction.Add(WaveType.sawtooth, SawtoothWave);
    }

    void Update() {
        randomValue = Random.value;
    }

    void OnAudioFilterRead(float[] data, int channels) {
        increment = frequency * pi_twice / sampling_frequency;
        gain = volume * .1;
        for (int i = 0; i < data.Length; i += channels) {
            UpdatePhase();
            data[i] = waveFunction[waveType]();
            if (channels == 2)
                data[i+1] = data[i];
        }
    }

    void UpdatePhase() {
        phase += increment;
        if (phase > pi_twice)
            phase -= pi_twice;
    }

    float SineWave() {
        return (float)(gain * Mathf.Sin((float)phase));
    }

    float SquareWave() {
        return (float)gain * (Mathf.Sin((float)phase) >= 0 ? .5f : -.5f);
    }

    float TriangleWave() {
        return (float)(gain * (double)Mathf.PingPong((float)phase, 1));
    }

    float SawtoothWave() {
        return (float)(gain * phase / pi_twice);
    }
}
