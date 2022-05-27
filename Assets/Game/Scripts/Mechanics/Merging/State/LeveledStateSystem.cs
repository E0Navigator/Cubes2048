using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Mechanics.Merging.State
{
    public abstract class LeveledStateSystem<TState> : StateSystem<TState>
    {
        private readonly IEnumerable<TState> _stateCollection;

        public int StateId { get; private set; }

        public event EventHandler<int> OnStateOutOfRange;

        protected LeveledStateSystem(IEnumerable<TState> stateCollection)
        {
            _stateCollection = stateCollection;
        }

        public void SetState(int id)
        {
            if (StateId < _stateCollection.Count())
            {
                SetState(_stateCollection.ElementAt(id));
                StateId = id;
            }
            else
            {
                OnStateOutOfRange?.Invoke(this, StateId);
            }
        }

        public void LevelUpState()
        {
            SetState(StateId + 1);
        }
    }
}