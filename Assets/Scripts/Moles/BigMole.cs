using System;
using UnityEngine;

namespace YK
{
    public class BigMole : Mole
    {
        public BigMole()
        {
            Health = 30;
            DisappearanceTime = 6.5f;
            ScoreCount = 30;
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
