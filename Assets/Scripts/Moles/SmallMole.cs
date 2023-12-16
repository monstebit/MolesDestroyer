using System;
using UnityEngine;

namespace YK
{
    public class SmallMole : Mole
    {
        public ScoreManager scoreManager;

        private void Awake()
        {
            scoreManager = GetComponent<ScoreManager>();
        }

        public SmallMole()
        {
            Health = 10;
            DisappearanceTime = 4.5f;
            ScoreCount = 10;
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