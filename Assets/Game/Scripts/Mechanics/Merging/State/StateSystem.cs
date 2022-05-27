using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanics.Merging.State
{
    public  abstract class StateSystem <TState>
    {
        public abstract void SetState(TState stateToSet);

    }
}