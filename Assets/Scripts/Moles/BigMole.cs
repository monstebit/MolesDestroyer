using System;
using UnityEngine;

namespace YK
{
    public class BigMole : Enemy
    {
        public BigMole()
        {
            Health = 30;
            DisappearanceTime = 6.5f;
            ScoreCount = 30;
            IncomingDamage = 10;
        }

        private void OnMouseDown()
        {
            DecreaseHealth(IncomingDamage);
        }
    }
}
