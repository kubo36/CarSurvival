using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LightingManager))]
public class CarController : MonoBehaviour
{
    public LightingManager lightingManager;
    public InputManager input;
    public UIManager uiManager;

    public List<WheelCollider> throttleWheels;
    public List<GameObject> steeringWheels;
    public List<GameObject> meshes;

    public float strengthCoefficient = 10000f;
    public float maxTurn = 20f;
    public Transform centerMass;
    public Rigidbody rb;
    public float brakeStrength = 300f;

    void Start()
    {
        input = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();

        if (centerMass)
        {
            rb.centerOfMass = centerMass.position;
        }
    }

    void Update()
    {
        if (input.lighting)
        {
            lightingManager.ToggleHeadlights();
        }

        if (input.brake)
        {
            lightingManager.ToggleBrakelightsOn();
        }
        else
        {
            lightingManager.ToggleBrakelightsOff();
        }
        // displays speed of the car depending on its position
        uiManager.ChangeText(transform.InverseTransformVector(rb.velocity).z);
    }


    void FixedUpdate()
    {
        // Movement of the car forward and backward plus brake function
        foreach(WheelCollider wheel in throttleWheels)
        {
            
            if (input.brake)
            {
                wheel.motorTorque = 0f;
                wheel.brakeTorque = brakeStrength * Time.fixedDeltaTime;
            }
            else
            {
                wheel.motorTorque = strengthCoefficient * Time.fixedDeltaTime * input.throttle;
                wheel.brakeTorque = 0f;
            }
        }
        // Movement of the wheels sideways
        foreach(GameObject wheel in steeringWheels)
        {
            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * input.steer;
            wheel.transform.localEulerAngles = new Vector3(0f, input.steer * maxTurn, 0f);
        }
        // Rotation of the wheels depending on the car moving forward or backward
        foreach(GameObject mesh in meshes)
        {
            mesh.transform.Rotate(rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z >= 0 ? 1 : -1)/ (2 * Mathf.PI * 0.33f), 0f, 0f);
        }
    }
}
