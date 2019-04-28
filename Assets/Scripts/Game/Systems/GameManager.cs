using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaveManager))]
public class GameManager : MonoBehaviour {

    public EnemyManager enemyManager;
    public PlayerManager playerManager;
    public float gameEndDelay;

    WaveManager waveManager;
    bool gameStarted;
    bool gameEnded;
    Utility.SimplePause pause;

    void Awake() {
        waveManager = GetComponent<WaveManager>();
    }

    void Start() {
        pause = Utility.SimplePause.instance;
        StartCoroutine(WaitForGameStart());
    }

    IEnumerator WaitForGameStart() {
        InputManager.instance.enabled = false;
        yield return new WaitUntil(() => GameMenu.instance.IsClosed());
        InputManager.instance.enabled = true;
        gameStarted = true;
        waveManager.StartNextWave();
    }

    void Update() {
        if (gameStarted && !gameEnded) {
            if (ShouldEndGame())
                StartCoroutine(GameEndRoutine());
            if (ShouldShowIntermissionMenu())
                StartCoroutine(ShowIntermissionMenuRoutine());
            if (Input.GetKeyDown(KeyCode.P))
                TogglePause();
        }
    }

    bool ShouldEndGame() {
        return !gameEnded && !playerManager.HasPlayer();
    }

    IEnumerator GameEndRoutine() {
        gameEnded = true;
        yield return new WaitForSeconds(gameEndDelay);
        GameOverScreen.instance.ShowGameOverScreen();
    }

    bool ShouldShowIntermissionMenu() {
        return WaveEnded() && !IntermissionMenus.instance.IsOpen();
    }

    bool WaveEnded() {
        return !enemyManager.HasEnemy();
    }

    IEnumerator ShowIntermissionMenuRoutine() {
        IntermissionMenus.instance.ShowIntermissionMenu();
        yield return new WaitUntil(() => !IntermissionMenus.instance.IsOpen());
        waveManager.StartNextWave();
    }

    void TogglePause() {
        pause.TogglePause();
        PausedScreen.instance.gameObject.SetActive(pause.paused);
    }
}
