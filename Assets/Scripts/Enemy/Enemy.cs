using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK
{
    public abstract class Enemy : MonoBehaviour
    {
        [Header("Particles")]
        [SerializeField] public ParticleSystem Explosion;

        [Header("Enemy Stats")]
        [SerializeField] private int _health;
        [SerializeField] private float _disappearanceTime;
        [SerializeField] private int _scoreCount;

        public int Health
        {
            get { return _health; }
            set
            {
                if (value >= 0)
                {
                    _health = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
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
        public int ScoreCount
        {
            get { return _scoreCount; }
            set
            {
                if (value >= 0)
                {
                    _scoreCount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }
        public int IncomingDamage { get; set; } = 10;

        public Enemy() { }

        public Enemy(int incomingDamage)
        {
            IncomingDamage = incomingDamage;
        }

        private void OnMouseDown()
        {
            DecreaseHealth(IncomingDamage);
        }

        protected void DecreaseHealth(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Destroy(gameObject);
                ParticlesExplode();

                //  ADD SCORE
                EventManager.OnEnemyDied(ScoreCount);
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
