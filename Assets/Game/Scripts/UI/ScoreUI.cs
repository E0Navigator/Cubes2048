using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
using Game.Mechanics.Scores;

namespace Game.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text scoreText;

        private ScoreSystem _scoreSystem;


        [Inject]
        private void Construct(ScoreSystem scoreSystem)
        {
            _scoreSystem = scoreSystem;
            scoreSystem.OnScoreUpdated += ScoreSystem_OnScoreUpdated;
        }

        private void ScoreSystem_OnScoreUpdated(object sender, int e)
        {
            scoreText.text = e.ToString();
        }
    }
}