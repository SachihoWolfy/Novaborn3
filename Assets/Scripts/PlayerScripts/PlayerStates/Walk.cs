using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
    public override void EnterState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 0f;
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
        Vector3 fixed_velocity = (desired_velocity + entity.rb.velocity).normalized * entity.move_speed;
        entity.rb.velocity = fixed_velocity;
        //if((Mathf.Abs(current_velocity.x) < entity.move_speed)) entity.rb.AddForce(new Vector3(desired_velocity.x*10,0,0));
        //if((Mathf.Abs(current_velocity.z) < entity.move_speed)) entity.rb.AddForce(new Vector3(0,0,desired_velocity.z*10));
    }
    public override void ExitState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 0f;
        controller.controlled_entity.rb.useGravity = true;
    }
}
