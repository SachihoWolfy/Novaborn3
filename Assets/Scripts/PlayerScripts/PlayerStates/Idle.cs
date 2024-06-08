using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public override void EnterState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 10f;
        controller.controlled_entity.rb.useGravity = false;
    }
    public override void UpdateState(StateController controller)
    {
        Entity entity = controller.controlled_entity;
        if(!entity.IsGrounded()) controller.ChangeStateTo(controller.falling);
        if(controller.controlled_entity.input_direction != Vector3.zero) controller.ChangeStateTo(controller.walk);
        if(Input.GetButtonDown("Jump")) controller.ChangeStateTo(controller.jump);
    }
    public override void FixedUpdateState(StateController controller)
    {
        return;
    }
    public override void ExitState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 0f;
        controller.controlled_entity.rb.useGravity = true;
    }
}
