using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace YK
{
    public class TitleScreenAndGameModeManager : MonoBehaviour
    {
        public static TitleScreenAndGameModeManager Instance;

        public GameMode currentGameMode = GameMode.NO_MODE;

        [Header("Grids & Moles Spawner")]
        [SerializeField] private GameObject _gridsAndMolesSpawnManager;

        [Header("Buttons")]
        [SerializeField] private Button _healthModeButton;
        [SerializeField] private Button _timerModeButton;

        [Header("Status Bars")]
        [SerializeField] private TextMeshProUGUI _scoreStatusBar; 
        [SerializeField] private TextMeshProUGUI _healthStatusBar; 
        [SerializeField] private TextMeshProUGUI _timerStatusBar; 

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

        private void ActivateGridsAndMoleSpawner()
        {
            _gridsAndMolesSpawnManager.SetActive(true);
        }

        public void StartHealthGameMode()
        {
            currentGameMode = GameMode.HealthGameMode;
            Debug.Log("Game starts in Health Mode");

            _healthModeButton.Select();

            _scoreStatusBar.gameObject.SetActive(true);
            _healthStatusBar.gameObject.SetActive(true);
            _timerStatusBar.gameObject.SetActive(false);  

            ActivateGridsAndMoleSpawner();
        }

        public void StartTimerGameMode()
        {
            currentGameMode = GameMode.TimerGameMode;
            Debug.Log("Game starts in Timer Mode");

            _timerModeButton.Select();


            _scoreStatusBar.gameObject.SetActive(false);
            _healthStatusBar.gameObject.SetActive(false);
            _timerStatusBar.gameObject.SetActive(true);

            ActivateGridsAndMoleSpawner();
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

