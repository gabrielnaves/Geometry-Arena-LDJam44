using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Upgrade : ScriptableObject {

    public string title;
    public string description;
    public int cost;

    abstract public void ApplyUpgrade();
}
