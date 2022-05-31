using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Mechanics.Scores;
using Game.Mechanics.Mergables.Leveled;
using Game.Mechanics.Mergables;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem finalParticle;
        [SerializeField]
        private int mergeLevelToFinish = 10;
        [SerializeField]
        private float mergeYPower = 1;

        public IMergingService<MergableObject<LeveledMergableObject>, LeveledMergableObject, MergableObject<LeveledMergableObject>, MergeInteractionData<LeveledMergableObject>> MergingService { get; private set; }


        [Inject]
        public void Construct(ScoreSystem scoreSystem,
            IMergingService<MergableObject<LeveledMergableObject>, LeveledMergableObject, MergableObject<LeveledMergableObject>, MergeInteractionData<LeveledMergableObject>> mergingService)
        {
            MergingService = mergingService;
            MergingService.OnMerged += OnMerged;

        }

        private void OnMerged(object sender, BaseMergeData<MergableObject<LeveledMergableObject>, LeveledMergableObject, MergableObject<LeveledMergableObject>, MergeInteractionData<LeveledMergableObject>> e)
        {

            LeveledMergableObject result = e.Result as LeveledMergableObject;
            result.Rigidbody.AddForce(Vector3.up * mergeYPower,ForceMode.Impulse);
            MergableState state = result.StateSystem.GetCurrentState();
            Debug.Log(state.Level);
            if (state.Level >= mergeLevelToFinish)
            {
                LevelFinished();
            }
        }
        private void LevelFinished()
        {
            finalParticle.gameObject.SetActive(true);
        }
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}