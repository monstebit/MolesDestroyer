using System;
using TMPro;
using UnityEngine;

namespace YK
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        private int _currentHealth;

        [SerializeField] private TextMeshProUGUI _healthText;

        public int MaxHealth
        {
            get { return _maxHealth; }
            set
            {
                if (value >= 0)
                {
                    _maxHealth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public int CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                _currentHealth = value;
            }
        }

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        private void Start()
        {
            _healthText.text = $"HEALTH: {_currentHealth}";
        }

        public void ApplyDamage(int damageValue)
        {
            _currentHealth -= damageValue;
            Debug.Log($"-{damageValue} HEALTH POINTS!");

            _healthText.text = $"HEALTH: {_currentHealth}";

            if (_currentHealth <= 0 )
            {
                _healthText.text = "";

                TitleScreenAndGameModeManager.Instance.RestartGame();
            }
        }
    }
}