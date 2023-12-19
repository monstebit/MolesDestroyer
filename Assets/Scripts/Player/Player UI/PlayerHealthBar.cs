using TMPro;
using UnityEngine;

namespace YK
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;

        [HideInInspector] private PlayerManager _playerManager;

        private void Awake()
        {
            _playerManager = GetComponent<PlayerManager>();
        }

        private void Start()
        {
            EventManager.PlayerDied += OnPlayerDied;

            _healthText.text = "HEALTH: " + _playerManager.MaxHealth.ToString();
        }

        private void OnDestroy()
        {
            EventManager.PlayerDied -= OnPlayerDied;
        }

        void OnPlayerDied(int enemyHealthValue)
        {
            if (_healthText != null)
            {
                _playerManager.MaxHealth -= enemyHealthValue;
                _healthText.text = "HEALTH: " + _playerManager.MaxHealth;
            }
        }

    }
}