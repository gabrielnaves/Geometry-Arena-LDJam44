using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameCamera : MonoBehaviour {

    public PlayerManager playerManager;

    CinemachineVirtualCamera virtualCamera;

    void Awake() {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Start() {
        if (playerManager.HasPlayer())
            virtualCamera.m_Follow = playerManager.GetCurrentPlayer().transform;
    }
}
