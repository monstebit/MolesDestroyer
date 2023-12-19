using System;
using UnityEngine;

namespace YK
{
    public class MiddleMole : Enemy
    {
        public MiddleMole()
        {
            Health = 20;
            DisappearanceTime = 3.5f;
            ScoreCount = 20;
            IncomingDamage = 10;
        }

        private void OnMouseDown()
        {
            DecreaseHealth(IncomingDamage);
        }
    }
}
