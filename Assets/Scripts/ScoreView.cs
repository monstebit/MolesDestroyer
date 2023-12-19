using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace YK
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private int _score = 0;
        
        void Start()
        {
            EventManager.EnemyDied += OnEnemyDied;
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
                _scoreText.text = "Score :" + _score;
            }
        }
    }
}
