using Game.Mechanics.Mergables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Mechanics.ObjectsLaunch
{
    public class ObjectsLaunchSystem : MonoBehaviour
    {
        [SerializeField]
        private float launchPower;
        [SerializeField]
        private Vector3 launchDirection;


        private Rigidbody _currentRigidbody;

        public float Power { get => launchPower; private set => launchPower = value; }
        public Rigidbody CurrentRigidbody { get => _currentRigidbody; set => _currentRigidbody = value; }

        public event Action OnLaunch;

        public void Launch(Rigidbody toLaunch)
        {
            toLaunch.AddForce(launchDirection * launchPower, ForceMode.Impulse);
            OnLaunch?.Invoke();

        }

    }
}