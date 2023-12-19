using System;
using UnityEngine;

namespace YK
{
    public class SmallMole : Enemy
    {
        public SmallMole()
        {
            Health = 10;
            DisappearanceTime = 4.5f;
            ScoreCount = 10;
            IncomingDamage = 10;
        }

        private void OnMouseDown()
        {
            DecreaseHealth(IncomingDamage);
        }
    }
}