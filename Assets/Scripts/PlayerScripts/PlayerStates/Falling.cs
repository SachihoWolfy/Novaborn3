using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : State
{
    public override void EnterState(StateController controller)
    {
        return;
    }
    public override void UpdateState(StateController controller)
    {
        Entity entity = controller.controlled_entity;
        if(entity.IsGrounded()) controller.ChangeStateTo(controller.idle);

        Vector3 desired_velocity = entity.input_direction * entity.move_speed * 10f;
        Vector3 current_velocity = new Vector3(entity.rb.velocity.x, 0f, entity.rb.velocity.z);
        Vector3 fixed_velocity = (desired_velocity + current_velocity).normalized * entity.move_speed;
        entity.rb.velocity = new Vector3(fixed_velocity.x, entity.rb.velocity.y, fixed_velocity.z);
    }
    public override void ExitState(StateController controller)
    {
        return;
    }
}
