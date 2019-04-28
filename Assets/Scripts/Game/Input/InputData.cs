using UnityEngine;

[CreateAssetMenu(menuName="Game/Data/InputData")]
public class InputData : ScriptableObject {

    [System.NonSerialized] public bool boost;
    [System.NonSerialized] public bool boostDown;
    [System.NonSerialized] public Vector3 mousePosition;
    [System.NonSerialized] public bool action;
    [System.NonSerialized] public bool actionDown;
    [System.NonSerialized] public bool actionUp;
}
