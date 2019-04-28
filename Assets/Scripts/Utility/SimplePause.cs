using UnityEngine;

namespace Utility {

    /// <summary>
    /// Implements pause/resume funcionality by setting time scale to zero.
    /// </summary>
    public class SimplePause : MonoBehaviour {

        static public SimplePause instance { get; private set; }

        public bool resumeOnAwake = true;
        [ViewOnly] public bool paused;

        public void Pause() {
            Time.timeScale = 0;
            paused = true;
        }

        public void Resume() {
            Time.timeScale = 1;
            paused = false;
        }

        public void TogglePause() {
            paused = !paused;
            Time.timeScale = paused ? 0 : 1;
        }

        void Awake() {
            instance = (SimplePause)Singleton.Setup(this, instance);
            if (resumeOnAwake)
                Resume();
        }
    }
}
