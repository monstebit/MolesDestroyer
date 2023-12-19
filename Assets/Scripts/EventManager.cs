using System;
using UnityEngine;

namespace YK
{
    public class EventManager : MonoBehaviour
    {
        public static event Action<int> EnemyDied;   //  �� ���� ����� ����� �������������   

        public static void OnEnemyDied(int scoreCount)    //  ���� ������� ����� �������� ���, ����� HP <= 0
        {
            EnemyDied?.Invoke(scoreCount);
        }
    }
}