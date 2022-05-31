using Game.Mechanics.States;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Game.Mechanics.Mergables.Leveled
{
    public abstract class LeveledStateSystem<TState> : StateSystem<TState>
    {
        private IEnumerable<TState> _stateCollection;

        public int StateId { get; private set; }

        public event EventHandler<int> OnStateOutOfRange;


        [Inject]
        public void Construct(IEnumerable<TState> stateCollection)
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

        public TState GetCurrentState()
        {
            return _stateCollection.ElementAt(StateId);
        }

        public void LevelUpState()
        {
            SetState(StateId + 1);
        }
    }
}