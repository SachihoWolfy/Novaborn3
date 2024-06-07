using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public Entity controlled_entity;
    State current_state;

    public State falling = new Falling();
    public State idle = new Idle();
    public State walk = new Walk();
    public State sprint = new Sprint();
    public State jump = new Jump();

    public void ChangeStateTo(State state)
    {
        current_state.ExitState(this);
        current_state = state;
        current_state.EnterState(this);
        StateDebugHud.instance.UpdateState(current_state.ToString());
    }

    public State GetCurrentState()
    {
        return current_state;
    }

    void Start()
    {
        current_state = idle;
    }

    void FixedUpdate()
    {
        // This breaks on High FPS as it will only update at 50 Times a second. Avoid Updating the state on Fixed Update. 
        //current_state.UpdateState(this);
    }

    private void Update()
    {
        current_state.UpdateState(this);
    }
}
