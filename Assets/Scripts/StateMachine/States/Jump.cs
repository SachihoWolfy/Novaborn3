using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
    public override void EnterState(StateController controller)
    {
        controller.ChangeStateTo(controller.idle);
        Entity entity = controller.controlled_entity;
        Vector3 force = new Vector3(0f, entity.jump_force, 0f);
        entity.rb.AddForce(force, ForceMode.Impulse);
    }
    public override void UpdateState(StateController controller)
    {
        return;
    }
    public override void ExitState(StateController controller)
    {
        return;
    }
}
