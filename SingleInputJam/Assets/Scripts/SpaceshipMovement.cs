using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public bool throttle => Input.GetKey(KeyCode.W);
    public bool rise => Input.GetKey(KeyCode.UpArrow);
    public GameObject spaceShip;

    //Some notes: 
    //Pitch controls how quickly the aircraft will rotate up or down
    //Roll controls how quickly the aircraft rotates left or right
    //Yaw controls whether the planee turns left or right
    //Engine power refers to how fast the aircraft will move forward

    public float pitchPower, rollPower, yawPower, enginePower;

    private float activePitch, activeRoll, activeYaw;

    private void Update()
    {
        if (throttle)
        {
            transform.position += transform.forward * enginePower * Time.deltaTime;
        }

        if (rise)
        {

            //transform.rotation += pitchPower * Time.deltaTime;
        }
    }
}
