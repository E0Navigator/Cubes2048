using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanics.States
{
    public abstract class StateSystem<TState> : MonoBehaviour
    {
        public abstract void SetState(TState stateToSet);

    }
}