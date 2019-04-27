using UnityEngine;

[CreateAssetMenu(menuName="Game/PlayerData")]
public class PlayerData : ScriptableObject {

    public float startingAcceleration;
    [ViewOnly] public float acceleration;
    public float startingMaxSpeed;
    [ViewOnly] public float maxSpeed;

    public void Setup() {
        acceleration = startingAcceleration;
        maxSpeed = startingMaxSpeed;
    }

    public void Reset() {
        acceleration = 0;
        maxSpeed = 0;
    }
}
