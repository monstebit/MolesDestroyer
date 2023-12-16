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

        // ���������� ���������� ����� �� ���������� �����
        protected override void AddScore()
        {
            ScoreManager.instance.AddScore(ScoreCount); // ���������� 10 ����� �� ���������� �����
            //Debug.Log("������������� �������� ������ ���������� �����");
            Destroy(gameObject);
        }
    }
}
