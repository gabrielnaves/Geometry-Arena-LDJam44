using UnityEngine;
using TMPro;

public class NumbersUtility : MonoBehaviour {

    static public NumbersUtility instance { get; private set; }

    public GameObject numberPrefab;

    void Awake() {
        instance = (NumbersUtility)Utility.Singleton.Setup(this, instance);
    }

    public void CreateNumberAt(Vector3 position, int value) {
        GameObject number = Instantiate(numberPrefab, position, Quaternion.identity, transform);
        var numberText = number.GetComponentInChildren<TextMeshProUGUI>();
        numberText.text = value.ToString();
        numberText.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
    }
}
