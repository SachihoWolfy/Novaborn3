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

        Vector3 desired_velocity = entity.input_direction * entity.move_speed;
        Vector3 fixed_velocity = (desired_velocity + entity.rb.velocity).normalized * entity.move_speed;
        entity.rb.AddForce(desired_velocity * 10f);
        if(entity.rb.velocity.magnitude > entity.move_speed)
            entity.rb.velocity = new Vector3(fixed_velocity.x, entity.rb.velocity.y, fixed_velocity.z);
    }
    public override void ExitState(StateController controller)
    {
        return;
    }
}
