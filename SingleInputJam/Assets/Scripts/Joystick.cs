using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;

    public bool Debugging;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.position = pointA * -1;
            outerCircle.position = pointA * -1;
            circle.GetComponent<Image>().enabled = true;
            outerCircle.GetComponent<Image>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;            
        }
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;

            if (Debugging)
            {
                Debug.Log("Direction: " + direction);
                Debug.Log("Point A: " + pointA);
                Debug.Log("Point B: " + pointB);
            }
        }
        else
        {
            circle.GetComponent<Image>().enabled = false;
            outerCircle.GetComponent<Image>().enabled = false;
        }
    }
}
