using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanics.Scores
{
    public class ScoreSystem : MonoBehaviour
    {
        private int score;
        public event EventHandler<int> OnScoreUpdated;

        public int Score
        {
            get => score;
            set
            {
                score = value;
                OnScoreUpdated?.Invoke(this, score);
                
            }
        }

        public void AddToScore(int toAdd)
        {
            Score += toAdd;
        }
        public void ClearScore()
        {
            Score = 0;
        }
    }
}