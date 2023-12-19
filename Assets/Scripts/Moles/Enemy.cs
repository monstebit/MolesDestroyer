using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK
{
    public abstract class Enemy : MonoBehaviour
    {
        [Header("Enemy Stats")]
        [SerializeField] private int _health;
        [SerializeField] private float _disappearanceTime;
        [SerializeField] private int _scoreCount;
        [SerializeField] private int _incomingDamage;

        [Header("Particles")]
        [SerializeField] public ParticleSystem Explosion;

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
        public int IncomingDamage
        {
            get { return _incomingDamage; }
            set
            {
                if (value >= 0)
                {
                    _incomingDamage = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public void DecreaseHealth(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                ParticlesExplode();
                AddScore();
            }
        }

        public void ParticlesExplode()
        {
            if (Explosion != null)
            {
                ParticleSystem explosionInstance = Instantiate(Explosion, transform.position, Quaternion.identity);
                explosionInstance.Play();

                Destroy(gameObject);
            }
        }

        //  SCORE
        public void AddScore()
        {
            ScoreManager.instance.GetScore(ScoreCount);
            Destroy(gameObject);
        }
    }
}
