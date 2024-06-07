using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody rb;
    public int layer_mask;

    [Header("Stats")]
    public float move_speed = 100;
    public float sprint_speed = 200;
    public float jump_force = 250;

    [Header("Inputs")]
    public Vector3 input_direction;

    [Header("GroundCheck")]
    public Collider collider_component;
    public bool IsGrounded()
    {
        float ray_length = collider_component.bounds.size.y + .2f;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, ray_length, ~layer_mask)) return true;
        else return false;
    }
    public Vector3 GroundAngle()
    {
        float ray_length = collider_component.bounds.size.y + .2f;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, ray_length, ~layer_mask);
        return hit.normal;
    }
}
