using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
    public override void EnterState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 0f;
        Entity entity = controller.controlled_entity;
        Vector3 entry_vel = entity.rb.velocity;
        entity.rb.velocity = Vector3.zero;
        entity.rb.AddForce(entity.transform.up * entity.jump_force, ForceMode.Impulse);
        entity.rb.velocity = new Vector3(entry_vel.x, entity.rb.velocity.y, entry_vel.z);
        controller.ChangeStateTo(controller.falling);
    }
    public override void UpdateState(StateController controller)
    {
        return;
    }
    public override void ExitState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 0f;
    }
}
