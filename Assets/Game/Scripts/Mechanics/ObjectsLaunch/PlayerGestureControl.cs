using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Game.Mechanics.ObjectsLaunch
{
    public class PlayerGestureControl : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        private LaunchObjectsSystem _launchObjectsSystem;

        [Inject]
        private void Construct(LaunchObjectsSystem launchObjectsSystem)
        {
            _launchObjectsSystem = launchObjectsSystem;
        }

        public void OnDrag(PointerEventData eventData)
        {

            //Debug.Log(eventData.delta);
            _launchObjectsSystem.Move(eventData.delta);
                
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _launchObjectsSystem.Launch();

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            
        }
    }
}