using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public bool throttle => Input.GetKey(KeyCode.Space);
    public bool rise => Input.GetKey(KeyCode.UpArrow);
    public GameObject spaceShip;

    //Some notes: 
    //Pitch controls how quickly the aircraft will rotate up or down
    //Roll controls how quickly the aircraft rotates left or right
    //Yaw controls whether the planee turns left or right
    //Engine power refers to how fast the aircraft will move forward

    public float pitchPower, rollPower, yawPower, enginePower;

    private float activePitch, activeRoll, activeYaw;

    public Joystick joystick;

    private void Update()
    {
        if (throttle)
        {
            transform.position += transform.forward * enginePower * Time.deltaTime; //Pushed the ship forward

            activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.deltaTime; //Asigns the active variables
            activeRoll = Input.GetAxisRaw("Horizontal") * rollPower * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Yaw") * yawPower * Time.deltaTime;

            transform.Rotate(activePitch * pitchPower * Time.deltaTime, 
                            activeYaw * yawPower * Time.deltaTime, 
                            activeRoll * rollPower * Time.deltaTime, Space.Self); //Transforms the objects rotation when the assigned inputs are pressed
        }
        else
        {
            transform.position += transform.forward * enginePower/2 * Time.deltaTime; //Pushed the ship forward

            activePitch = Input.GetAxisRaw("Vertical") * pitchPower/2 * Time.deltaTime; //Asigns the active variables
            activeRoll = Input.GetAxisRaw("Horizontal") * rollPower/2 * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Yaw") * yawPower/2 * Time.deltaTime;

            transform.Rotate(activePitch * pitchPower * Time.deltaTime,
                            activeYaw * yawPower * Time.deltaTime,
                            activeRoll * rollPower * Time.deltaTime, Space.Self); //Transforms the objects rotation when the assigned inputs are pressed
        }


    }
}
