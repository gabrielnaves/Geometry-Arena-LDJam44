using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerManager playerManager;

    PlayerMovement playerMovement;
    PlayerShootingControls shootControls;

    void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        shootControls = GetComponent<PlayerShootingControls>();
        playerManager.AddPlayer(this);
    }

    void OnDestroy() {
        playerManager.RemovePlayer(this);
    }
}
