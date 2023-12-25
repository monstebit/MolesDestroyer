using System;
using UnityEngine;

namespace YK
{
    public class EnemyEventManager : MonoBehaviour
    {
        public static event Action<int> EnemyDied;      //  мю щрнр щбемр асдел ондохяшбюрэяъ   

        public static void OnEnemyDied(int scoreAmount)  //  щрхл лернднл лнфмн бшгшбюрэ ецн, йнцдю HP <= 0
        {
            EnemyDied?.Invoke(scoreAmount);
        }
    }
}