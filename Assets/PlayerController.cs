using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    [SerializeField]
    public float lookSensitivity = 3f;


    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }


    private void Update()
    {
        //movement 3D Vector
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        motor.Move(velocity);

        //rotation 3D Vector

        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;
        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;

        motor.Rotate(rotation);
        motor.RotateCamera(cameraRotation);
    }
}
