using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(WaveManager))]
public class GameManager : MonoBehaviour {

    public EnemyManager enemyManager;
    public PlayerManager playerManager;
    public float gameEndDelay;

    WaveManager waveManager;
    bool gameEnded;

    void Awake() {
        waveManager = GetComponent<WaveManager>();
    }

    void Start() {
        waveManager.StartNextWave();
    }

    void Update() {
        if (ShouldEndGame())
            StartCoroutine(GameEndRoutine());
        if (ShouldShowIntermissionMenu())
            StartCoroutine(ShowIntermissionMenuRoutine());
    }

    bool ShouldEndGame() {
        return !gameEnded && !playerManager.HasPlayer();
    }

    IEnumerator GameEndRoutine() {
        yield return new WaitForSeconds(gameEndDelay);
        gameEnded = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
