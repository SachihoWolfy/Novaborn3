using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
    public override void EnterState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 0f;
    }
    public override void UpdateState(StateController controller)
    {
        Entity entity = controller.controlled_entity;
        entity.rb.velocity = new Vector3(entity.rb.velocity.x, 0f, entity.rb.velocity.z);
        Vector3 force = new Vector3(0f, entity.jump_force, 0f);
        entity.rb.AddForce(force, ForceMode.Impulse);
        controller.ChangeStateTo(controller.falling);
    }
    public override void ExitState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 0f;
    }
}
