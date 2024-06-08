using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class State
{
    public abstract void EnterState(StateController controller);
    public abstract void UpdateState(StateController controller);
    public abstract void FixedUpdateState(StateController controller);
    public abstract void ExitState(StateController controller);
}
