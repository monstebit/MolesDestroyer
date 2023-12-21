using TMPro;
using UnityEngine;

namespace YK
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;

        [HideInInspector] private PlayerStatsManager _playerStatsManager;

        private void Awake()
        {
            _playerStatsManager = GetComponent<PlayerStatsManager>();
        }

        private void Start()
        {
            _healthText.text = "HEALTH: " + _playerStatsManager.CurrentHealth.ToString();
            Debug.Log("PlayerHealthBar START. CurrentHealth: " + _playerStatsManager.CurrentHealth);

            EventManager.PlayerDied += OnPlayerDied;

        }

        private void OnDestroy()
        {
            EventManager.PlayerDied -= OnPlayerDied;
        }

        void OnPlayerDied(int enemyHealthValue)
        {
            if (_healthText != null)
            {
                _playerStatsManager.CurrentHealth -= enemyHealthValue;
                _healthText.text = "HEALTH: " + _playerStatsManager.CurrentHealth;
            }
        }
    }
}