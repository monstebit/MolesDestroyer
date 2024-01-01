using TMPro;
using UnityEngine;

namespace YK
{
    public class PlayerScoreBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private int _score = 0;

        private void OnEnable()
        {
            EnemyEventManager.EnemyDied += ScoreUpdate;
        }

        void Start()
        {
            _scoreText.text = $"SCORE: {_score}";
        }

        private void OnDisable()
        {
            EnemyEventManager.EnemyDied -= ScoreUpdate;
        }

        void ScoreUpdate(int scoreAmount)
        {
            if (_scoreText != null)
            {
                _score += scoreAmount;
                _scoreText.text = $"SCORE: {_score}";
            }
        }
    }
}
