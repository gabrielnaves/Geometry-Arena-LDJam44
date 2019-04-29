using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameCamera : MonoBehaviour {

    public PlayerManager playerManager;
    public CameraShakeData shake;

    CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin perlin;

    void Awake() {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        shake.Reset();
    }

    void Start() {
        if (playerManager.HasPlayer())
            virtualCamera.m_Follow = playerManager.GetCurrentPlayer().transform;
    }

    void Update() {
        shake.Update();
        perlin.m_AmplitudeGain = shake.amplitude;
        perlin.m_FrequencyGain = shake.frequency;
    }

    void OnDestroy() {
        shake.Reset();
    }
}
