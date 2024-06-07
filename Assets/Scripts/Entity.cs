using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components
    public Rigidbody rb;
    public Collider collider_component;
    public int layer_mask;
    #endregion

    #region Stats
    public float move_speed = 100;
    public float sprint_speed = 200;
    public float jump_force = 250;
    #endregion

    #region Input
    public Vector3 input_direction;
    #endregion

    #region Groundcheck
    public bool IsGrounded()
    {
        float ray_length = collider_component.bounds.size.y/2 + .2f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, ray_length, ~layer_mask))
        {
            Debug.DrawRay(transform.position, -Vector3.up * ray_length, Color.green);
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, -Vector3.up * ray_length, Color.red);
            return false;
        }
    }
    public Vector3 GroundAngle()
    {
        float ray_length = collider_component.bounds.size.y/2 + .2f;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, ray_length, ~layer_mask);
        return hit.normal;
    }
    #endregion
}
