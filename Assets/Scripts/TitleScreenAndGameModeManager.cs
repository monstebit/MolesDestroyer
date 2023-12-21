using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace YK
{
    public class TitleScreenAndGameModeManager : MonoBehaviour
    {
        public static TitleScreenAndGameModeManager Instance;

        public GameMode currentGameMode;

        [SerializeField] private GameObject _spawnManager;

        [Header("Buttons")]
        [SerializeField] private Button _healthModeButton;
        [SerializeField] private Button _timerModeButton;

        [Header("Status Bars")]
        [SerializeField] private GameObject _scoreStatusBar; 
        [SerializeField] private GameObject _healthStatusBar; 
        [SerializeField] private GameObject _timerStatusBar; 

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void ActivateGridAndMoleSpawner()
        {
            _spawnManager.SetActive(true);
        }

        public void StartHealthGameMode()
        {
            currentGameMode = GameMode.HealthGameMode;
            Debug.Log("Game starts in Health Mode");

            _healthModeButton.Select();

            _scoreStatusBar.SetActive(true);
            _healthStatusBar.SetActive(true);
            _timerStatusBar.SetActive(false);  

            ActivateGridAndMoleSpawner();
        }

        public void StartTimerGameMode()
        {
            currentGameMode = GameMode.TimerGameMode;
            Debug.Log("Game starts in Timer Mode");

            _timerModeButton.Select();


            _scoreStatusBar.SetActive(false);
            _healthStatusBar.SetActive(false);
            _timerStatusBar.SetActive(true);

            ActivateGridAndMoleSpawner();
        }

        public void RestartGame()
        {
            Debug.Log("Restart Game");
            ReloadScene();
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
    }
}

