using System;
using UnityEngine;

namespace YK
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;

        public float time = 60.0f; // время таймера в секундах

        private Time _time;

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

        private void Start()
        {
            _currentHealth = _maxHealth;

            if (_currentHealth <= 0)
            {
                Debug.Log("You dead");
            }

            
        }
    }
}

