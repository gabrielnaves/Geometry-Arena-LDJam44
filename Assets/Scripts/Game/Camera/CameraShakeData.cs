using UnityEngine;

[CreateAssetMenu(menuName="Game/Data/CameraShakeData")]
public class CameraShakeData : ScriptableObject {

    public float maxAmplitude;
    public float frequency;
    public float traumaDecayTime = 1;
    [ViewOnly] public float trauma;

    public float amplitude { get { return maxAmplitude * trauma * trauma; }}

    float traumaDecay;

    public void Reset() {
        trauma = 0;
        traumaDecay = 1 / traumaDecayTime;
    }

    public void AddTrauma(float value) {
        trauma = Mathf.Clamp01(trauma + value);
    }

    public void Update() {
        trauma = Mathf.Clamp01(trauma - Time.deltaTime * traumaDecay);
    }
}
