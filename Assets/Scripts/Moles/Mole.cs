using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK
{
    public abstract class Mole : MonoBehaviour
    {
        public static Action OnScoreUpdated;

        [SerializeField] public int Health { get; protected set; }
        [SerializeField] public float DisappearanceTime { get; protected set; }
        [SerializeField] public int ScoreCount { get; protected set; }


        [SerializeField] private ParticleSystem Explosion;

        private void OnMouseDown()
        {
            DecreaseHealth(10);
        }

        private void DecreaseHealth(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Explode();
            }
        }

        private void Explode()
        {
            if (Explosion != null)
            {
                ParticleSystem explosionInstance = Instantiate(Explosion, transform.position, Quaternion.identity);
                explosionInstance.Play();

                Destroy(gameObject);

                AddScore();
            }
        }

        // ƒобавление очков в зависимости от типа крота
        protected abstract void AddScore();
    }
}
