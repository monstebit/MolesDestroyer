using System;
using UnityEngine;

namespace YK
{
    public class EnemyEventManager : MonoBehaviour
    {
        public static event Action<int> EnemyDied;      //  �� ���� ����� ����� �������������   

        public static void OnEnemyDied(int scoreAmount)  //  ���� ������� ����� �������� ���, ����� HP <= 0
        {
            EnemyDied?.Invoke(scoreAmount);
        }
    }
}