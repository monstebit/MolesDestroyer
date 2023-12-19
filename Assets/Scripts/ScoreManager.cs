using System;
using UnityEngine;

namespace YK
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;

        //public Action OnScoreUpdated;
        public delegate void ScoreUpdatedEventHandler(int newScore);
        public static event ScoreUpdatedEventHandler OnScoreUpdated;

        private int _score;

        //public int Score => score;
        public int Score
        {
            get
            {
                return _score;
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
        public void GetScore(int points)
        {
            _score += points;
            OnScoreUpdated?.Invoke(points);
        }
    }
}