using System;
using Unity.VisualScripting;
using UnityEngine;

namespace YK
{
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        [HideInInspector] private EnemySoundFXManager _soundFXManager;

        [Header("Particles")]
        [SerializeField] public ParticleSystem Explosion;

        [Header("Enemy Stats")]
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;
        [SerializeField] private float _disappearanceTime;
        [SerializeField] private int _scoreValue;
        //  ADD DAMAGE * DISSAPEARANCE TIME?

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

        public float DisappearanceTime
        {
            get { return _disappearanceTime; }
            set
            {
                if (value >= 0)
                {
                    _disappearanceTime = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public int ScoreValue
        {
            get { return _scoreValue; }
            set
            {
                if (value >= 0)
                {
                    _scoreValue = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public int ImpactDamage { get; set; } = 10;

        public Enemy() { }

        public Enemy(int incomingDamage)
        {
            ImpactDamage = incomingDamage;
        }

        private void Awake()
        {
            _soundFXManager = GetComponent<EnemySoundFXManager>();
        }

        protected void Start()
        {
            _currentHealth = MaxHealth;


        }

        protected void OnMouseDown()
        {
            ApplyDamage(ImpactDamage);
        }

        public void ApplyDamage(int damageValue)
        {
            _currentHealth -= damageValue;
            Debug.Log("Enemy current health is: " + _currentHealth);

            //  PLAY APPLY DAMAGE SOUND FX
            //_soundFXManager.PlayDestroySoundFX();

            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
                ParticlesExplode();

                //  ADD SCORE
                EnemyEventManager.OnEnemyDied(ScoreValue);
                Debug.Log("+" + _scoreValue);

                //  SOUND FX AFTER DESTROY
                EnemyEventManager.OnEnemyDiedSoundFX();
            }
        }

        protected void ParticlesExplode()
        {
            if (Explosion != null)
            {
                ParticleSystem explosionInstance = Instantiate(Explosion, transform.position, Quaternion.identity);
                explosionInstance.Play();
            }
        }
    }
}
