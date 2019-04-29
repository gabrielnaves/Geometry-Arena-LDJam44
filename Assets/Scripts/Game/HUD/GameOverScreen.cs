using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    static public GameOverScreen instance { get; private set; }

    public WaveData waveData;
    public TextMeshProUGUI finalText;
    public float delay = 1;
    public AudioClip gameOverSound;
    public float gameOverSoundDelay;
    public string[] waveTexts;

    Animator animator;
    CanvasGroup canvasGroup;

    void Start() {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        enabled = false;
    }

    void Awake() {
        instance = (GameOverScreen)Utility.Singleton.Setup(this, instance);
    }

    void Update() {
        if (Time.timeSinceLevelLoad > delay && Input.anyKeyDown)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowGameOverScreen() {
        SoundEffectUtility.instance.PlaySoundDelayed(gameOverSound, gameOverSoundDelay);
        enabled = true;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        animator.SetBool("GameEnded", true);
        if (waveData.currentWave >= waveTexts.Length)
            finalText.text = waveTexts[waveTexts.Length - 1];
        else
            finalText.text = waveTexts[waveData.currentWave];
    }
}
