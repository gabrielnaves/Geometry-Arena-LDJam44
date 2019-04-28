using UnityEngine;

public class LifeOrbUtility : MonoBehaviour {

    static public LifeOrbUtility instance { get; private set; }

    public GameObject lifeOrbPrefab;

    void Awake() {
        instance = (LifeOrbUtility)Utility.Singleton.Setup(this, instance);
    }

    public void CreateOrbsAt(Vector3 position, int amount) {
        for (int i = 0; i < amount; ++i)
            Instantiate(lifeOrbPrefab, position, Quaternion.identity, transform);
    }
}
