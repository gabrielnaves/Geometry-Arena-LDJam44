using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    static public Player instance { get; private set; }

    public PlayerManager playerManager;

    PlayerMovement playerMovement;

    void Awake() {
        instance = (Player)Utility.Singleton.Setup(this, instance);
        playerMovement = GetComponent<PlayerMovement>();
        playerManager.AddPlayer(this);
    }

    void OnDestroy() {
        playerManager.RemovePlayer(this);
    }
}
