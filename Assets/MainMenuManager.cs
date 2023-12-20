using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace YK
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuManager Instance;

        public GameMode currentGameMode;

        [SerializeField] private GameObject _spawner;

        [SerializeField] private GameObject hpModeMenu;
        [SerializeField] private GameObject timerModMenu;

        [SerializeField] private GameObject healthBarGO;
        [SerializeField] private GameObject scoreBarGO;
        [SerializeField] private GameObject timerBarGO;

        [SerializeField] private Button HPModeButton;
        [SerializeField] private Button TimerButton;

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

        private void NewGame()
        {
            _spawner.SetActive(true);
        }

        public void StartHPMod()
        {
            currentGameMode = GameMode.HPMod;

            //  CLOSE LOAD MENU
            timerModMenu.SetActive(false);

            //  SELECT THE LOAD BUTTON
            HPModeButton.Select();

            // ������ ��� ������ ���� � ������� HP Mod
            Debug.Log(currentGameMode);
            Debug.Log("���� ������ � ������ HP Mod");

            NewGame();
            healthBarGO.SetActive(true);
            scoreBarGO.SetActive(true);
        }

        public void StartTimerMod()
        {
            currentGameMode = GameMode.TimerMod;

            //  CLOSE LOAD MENU
            hpModeMenu.SetActive(false);

            //  SELECT THE LOAD BUTTON
            TimerButton.Select();

            Debug.Log(currentGameMode);

            // ������ ��� ������ ���� � ������� Timer Mod
            Debug.Log("���� ������ � ������ Timer Mod");

            NewGame();
            timerBarGO.SetActive(true);
            scoreBarGO.SetActive(true);
        }

        public void EndGame()
        {
            Debug.Log("���� ���������!");
            // ����� ����� �������� ����� ������ ���������� ����, ��������, ������������ �����
            ReloadScene();
        }

        public void ReloadScene()
        {
            // ����� ������������ ������� �����
            SceneManager.LoadScene("SampleScene");
        }
    }
}

