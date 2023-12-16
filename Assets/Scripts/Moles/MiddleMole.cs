using System;
using UnityEngine;

namespace YK
{
    public class MiddleMole : Mole
    {
        public MiddleMole()
        {
            Health = 20;
            DisappearanceTime = 3.5f;
            ScoreCount = 20;
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
