using System;
using UnityEngine;

namespace YK
{
    public class ScoreManager : MonoBehaviour
    {
        // Singleton instance
        public static ScoreManager instance;

        // Event to notify when the score is updated
        public Action OnScoreUpdated;
        //public delegate void ScoreUpdatedEventHandler(int newScore);
        //public static event ScoreUpdatedEventHandler OnScoreUpdated;

        // Current score
        private int score;

        //public int Score => score;
        public int Score
        {
            get
            {
                // ¬озвращаем текущее значение приватного пол€ score
                return score;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Add score and notify subscribers
        public void AddScore(int points)
        {
            score += points;
            OnScoreUpdated?.Invoke();
        }
    }
}