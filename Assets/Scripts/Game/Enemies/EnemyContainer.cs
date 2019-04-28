using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour {

    static public EnemyContainer instance { get; private set; }

    void Awake() {
        instance = (EnemyContainer)Utility.Singleton.Setup(this, instance);
    }
}
