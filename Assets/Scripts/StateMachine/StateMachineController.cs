using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public State current_state;
    void ChangeStateTo(State state)
    {
        current_state.ExitState();
        current_state = state;
        current_state.EnterState();
    }

    State GetCurrentState()
    {
        return current_state;
    }

    void Update()
    {
        current_state.UpdateState();
    }
}
