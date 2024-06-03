using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : State
{
    public override void EnterState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 1f;
    }
    public override void UpdateState(StateController controller)
    {
        Entity entity = controller.controlled_entity;
        if(entity.input_direction == Vector3.zero) controller.ChangeStateTo(controller.idle);
        if(!entity.IsGrounded()) controller.ChangeStateTo(controller.falling);
        if(Input.GetButtonDown("Jump")) controller.ChangeStateTo(controller.jump);
        if(!Input.GetButton("Sprint")) controller.ChangeStateTo(controller.walk);

        Vector3 desired_velocity = entity.input_direction * entity.sprint_speed * 10f;
        Vector3 current_velocity = new Vector3(entity.rb.velocity.x, 0f, entity.rb.velocity.z);
        Vector3 fixed_velocity = (desired_velocity + current_velocity).normalized * entity.sprint_speed;
        entity.rb.velocity = new Vector3(fixed_velocity.x, entity.rb.velocity.y, fixed_velocity.z);
    }
    public override void ExitState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 0;
    }
}
