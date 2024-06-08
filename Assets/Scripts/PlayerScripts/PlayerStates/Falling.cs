using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : State
{
    private Vector3 current_velocity, desired_velocity, fixed_velocity;

    public override void EnterState(StateController controller)
    {
        return;
    }
    public override void UpdateState(StateController controller)
    {
        Entity entity = controller.controlled_entity;
        if(entity.IsGrounded()) controller.ChangeStateTo(controller.idle);
        desired_velocity = entity.input_direction * entity.move_speed * entity.air_control;
        current_velocity = new Vector3(entity.rb.velocity.x, 0f, entity.rb.velocity.z);
        fixed_velocity = (desired_velocity + entity.rb.velocity).normalized * entity.sprint_speed;
        if(entity.rb.velocity.magnitude > entity.sprint_speed)
            entity.rb.velocity = new Vector3(fixed_velocity.x, entity.rb.velocity.y, fixed_velocity.z);
    }
    public override void FixedUpdateState(StateController controller)
    {
        Entity entity = controller.controlled_entity;
        entity.rb.AddForce(desired_velocity * 10f);
    }
    public override void ExitState(StateController controller)
    {
        return;
    }
}
