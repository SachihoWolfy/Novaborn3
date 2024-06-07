using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
    public override void EnterState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 1f;
        controller.controlled_entity.rb.useGravity = false;
    }
    public override void UpdateState(StateController controller)
    {
        Entity entity = controller.controlled_entity;
        if(entity.input_direction == Vector3.zero) controller.ChangeStateTo(controller.idle);
        if(!entity.IsGrounded()) controller.ChangeStateTo(controller.falling);
        if(Input.GetButtonDown("Jump")) controller.ChangeStateTo(controller.jump);
        if(Input.GetButton("Sprint")) controller.ChangeStateTo(controller.sprint);

        Vector3 move_direction = Vector3.ProjectOnPlane(entity.input_direction, entity.GroundAngle()).normalized;
        Vector3 desired_velocity = move_direction * entity.move_speed;
        Vector3 current_velocity = new Vector3(entity.rb.velocity.x, 0f, entity.rb.velocity.z);
        Vector3 fixed_velocity = (desired_velocity + entity.rb.velocity).normalized * entity.move_speed;
        entity.rb.AddForce(desired_velocity * 10f);
        if(current_velocity.magnitude > entity.move_speed)
            entity.rb.velocity = new Vector3(fixed_velocity.x, entity.rb.velocity.y, fixed_velocity.z);
    }
    public override void ExitState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 0f;
        controller.controlled_entity.rb.useGravity = true;
    }
}
