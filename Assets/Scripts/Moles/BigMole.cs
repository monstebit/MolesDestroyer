using System;
using UnityEngine;

namespace YK
{
    public class BigMole : Mole
    {
        public BigMole()
        {
            Health = 30;
            DisappearanceTime = 6.5f;
            ScoreCount = 30;
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
