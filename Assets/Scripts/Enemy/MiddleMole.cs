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
        }

        public MiddleMole(int incomingDamage) : base(incomingDamage)
        {

        }

        private void OnMouseDown()
        {
            DecreaseHealth(IncomingDamage);
        }
    }
}
