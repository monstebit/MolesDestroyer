using System;
using UnityEngine;

namespace YK
{
    public class EventManager : MonoBehaviour
    {
        public static event Action<int> EnemyDied;   //  мю щрнр щбемр асдел ондохяшбюрэяъ   
        public static event Action<int> PlayerDied;    

        public static void OnEnemyDied(int scoreCount)    //  щрхл лернднл лнфмн бшгшбюрэ ецн, йнцдю HP <= 0
        {
            EnemyDied?.Invoke(scoreCount);
        }

        public static void OnPlayerDied(int enemyHealthValue)  
        {
            PlayerDied?.Invoke(enemyHealthValue);
        }
    }
}