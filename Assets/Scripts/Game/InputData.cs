using UnityEngine;

[CreateAssetMenu(menuName="Game/InputData")]
public class InputData : ScriptableObject {

    [System.NonSerialized] public bool boost;
    [System.NonSerialized] public bool boostDown;
    [System.NonSerialized] public Vector3 mousePosition;
}
