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
            EnemyEventManager.EnemyDied += Died;

            _scoreText.text = "SCORE: " + _score;
        }

        private void OnDestroy()
        {
            EnemyEventManager.EnemyDied -= Died;
        }

        void Died(int scoreAmount)
        {
            if (_scoreText != null)
            {
                _score += scoreAmount;
                _scoreText.text = "SCORE: " + _score;
            }
        }
    }
}
