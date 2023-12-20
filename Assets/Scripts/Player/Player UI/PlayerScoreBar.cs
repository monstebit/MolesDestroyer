using TMPro;
using UnityEngine;

namespace YK
{
    public class PlayerScoreBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private int _score = 0;
        
        void Start()
        {
            EventManager.EnemyDied += OnEnemyDied;

            _scoreText.text = "SCORE: " + _score;
        }

        private void OnDestroy()
        {
            EventManager.EnemyDied -= OnEnemyDied;
        }

        void OnEnemyDied(int scoreCount)
        {
            if (_scoreText != null)
            {
                _score += scoreCount;
                _scoreText.text = "SCORE: " + _score;
            }
        }
    }
}
