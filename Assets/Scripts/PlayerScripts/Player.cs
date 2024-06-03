using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        input_direction = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
    }
}
