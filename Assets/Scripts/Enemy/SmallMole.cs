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
        }

        public SmallMole(int incomingDamage) : base(incomingDamage) 
        {
            
        }
    }
}