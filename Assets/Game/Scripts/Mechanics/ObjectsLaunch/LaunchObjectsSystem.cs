using Game.Mechanics.Mergables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Mechanics.ObjectsLaunch
{
    public class LaunchObjectsSystem : MonoBehaviour
    {
        [SerializeField]
        private float launchPower;
        [SerializeField]
        private Vector3 launchDirection;

        [SerializeField]
        private Transform dragPoint1;
        [SerializeField]
        private Transform dragPoint2;
        [SerializeField]
        private float sensitivity = 0.1f;

        private Rigidbody _currentRigidbody;
        private LaunchObjectsSpawn _launchObjectsSpawn;

        public float Power { get => launchPower; private set => launchPower = value; }
        public Rigidbody CurrentRigidbody { get => _currentRigidbody; set => _currentRigidbody = value; }

        public event Action OnLaunch;

        public void Move(Vector2 delta)
        {
            if (CurrentRigidbody != null)
            {
                Vector3 dragVector = dragPoint2.position - dragPoint1.position;
                Vector3 toMove = CurrentRigidbody.position + dragVector.normalized * (delta.x * sensitivity);
                toMove.x = Mathf.Clamp(toMove.x, dragPoint1.position.x, dragPoint2.position.x);
                CurrentRigidbody.MovePosition(toMove);
            }
        }

        [Inject]
        private void Construct(LaunchObjectsSpawn objectsSpawn)
        {
            _launchObjectsSpawn = objectsSpawn;

        }
        private void Start()
        {
            _launchObjectsSpawn.OnObjectSpawned += LaunchObjectsSpawn_OnObjectSpawned;
            _launchObjectsSpawn.Spawn();
        }

        private void LaunchObjectsSpawn_OnObjectSpawned(object sender, Rigidbody e)
        {
            CurrentRigidbody = e;
            CurrentRigidbody.isKinematic = true;
        }

        public void Launch()
        {
            if (CurrentRigidbody != null)
            {
                print("Launch!");
                CurrentRigidbody.isKinematic = false;
                CurrentRigidbody.AddForce(launchDirection * launchPower, ForceMode.Impulse);
                CurrentRigidbody = null;
                _launchObjectsSpawn.Spawn();
                OnLaunch?.Invoke();
                
            }

        }


    }
}