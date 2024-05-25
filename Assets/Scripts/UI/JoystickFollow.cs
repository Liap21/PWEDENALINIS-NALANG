using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickFollow : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void Update()
    {
        FaceJoystick();
    }

    private void FaceJoystick()
    {
        Vector2 joystickDirection = playerController.GetLastInput();

        if (joystickDirection.magnitude > 0.1f) 
        {
            
            float angle = Mathf.Atan2(joystickDirection.y, joystickDirection.x) * Mathf.Rad2Deg;
            
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
