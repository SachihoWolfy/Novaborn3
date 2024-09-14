using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducking : State
{
    private Vector3 size;
    private bool touchedGround;
    private CapsuleCollider[] capsuleColliders;
    public override void EnterState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 10f;
        controller.controlled_entity.rb.useGravity = true;
        capsuleColliders = controller.controlled_entity.gameObject.GetComponents<CapsuleCollider>();
        touchedGround = false;
        foreach (CapsuleCollider capsuleCollider in capsuleColliders){
            capsuleCollider.height = 1f;
        }
    }
    public override void UpdateState(StateController controller)
    {
        Entity entity = controller.controlled_entity;
        if (touchedGround)
        {
            if (!entity.IsGrounded()) controller.ChangeStateTo(controller.falling);
        }
        else
        {
            touchedGround = entity.IsGrounded();
        }
        if (controller.controlled_entity.input_direction != Vector3.zero) controller.ChangeStateTo(controller.walk);
        if (Input.GetKeyUp(KeyCode.C)) controller.ChangeStateTo(controller.idle);
        if (Input.GetButtonDown("Jump")) controller.ChangeStateTo(controller.jump);
    }
    public override void FixedUpdateState(StateController controller)
    {
        return;
    }
    public override void ExitState(StateController controller)
    {
        controller.controlled_entity.rb.drag = 0f;
        foreach (CapsuleCollider capsuleCollider in capsuleColliders)
        {
            capsuleCollider.height = 1.9f;
        }
    }
}
