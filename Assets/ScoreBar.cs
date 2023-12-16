using TMPro;
using UnityEngine;

namespace YK
{
    public class ScoreBar : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
        public ScoreManager scoreManager;

        private void Update()
        {
            int currentScore = scoreManager.Score;

            // ����������� �������� � ������ � ������������� � TextMeshProUGUI
            scoreText.text = "SCORE IS: " + currentScore.ToString();
        }
    }
}
