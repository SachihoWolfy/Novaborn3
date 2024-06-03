using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensitivity;

    float rotation_x;
    float rotation_y;
    public GameObject player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position;
        float mouse_x = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float mouse_y = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        rotation_x = Mathf.Clamp(rotation_x - mouse_y, -90f, 90f);
        rotation_y += mouse_x;

        transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
        player.transform.rotation = Quaternion.Euler(0, rotation_y, 0);
    }
}
