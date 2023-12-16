using System;
using UnityEngine;

namespace YK
{
    public class SmallMole : Mole
    {
        public ScoreManager scoreManager;

        private void Awake()
        {
            scoreManager = GetComponent<ScoreManager>();
        }

        public SmallMole()
        {
            Health = 10;
            DisappearanceTime = 4.5f;
            ScoreCount = 10;
        }

        // Реализация добавления очков за маленького крота
        protected override void AddScore()
        {
            ScoreManager.instance.AddScore(ScoreCount); // Добавление 10 очков за маленького крота
            //Debug.Log("Проигрывается анимация взрыва маленького крота");
            Destroy(gameObject);
        }
    }
}