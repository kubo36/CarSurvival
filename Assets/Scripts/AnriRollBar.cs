using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnriRollBar : MonoBehaviour
{
    public WheelCollider wheelL;
    public WheelCollider wheelR;
    private Rigidbody carRigidBody;

    public float antiRoll = 5000.0f;

    // Start is called before the first frame update
    void Start()
    {
        carRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WheelHit hit = new WheelHit();
        float travelL = 1.0f;
        float travelR = 1.0f;

        // checks if its grounded, if true output is stored in hit
        bool groundedL = wheelL.GetGroundHit(out hit);

        if (groundedL)
        {
            // distance below the car from the point where wheel touches the ground using y value subtracting the wheel radius to get the location
            // of the wheel relative to the car divided by the suspension distance
            travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) / wheelL.suspensionDistance;

        }

        bool groundedR = wheelR.GetGroundHit(out hit);

        if (groundedR)
        {
            // distance below the car from the point where wheel touches the ground using y value subtracting the wheel radius to get the location
            // of the wheel relative to the car divided by the suspension distance
            travelR = (-wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) / wheelR.suspensionDistance;
        }

        // modulates the antiRollForce such that car rolls left antiRollForce applies right and vice versa
        var antiRollForce = (travelL - travelR) * antiRoll;

        if (groundedL)
        {
            // adding the force at the position of the wheel
            carRigidBody.AddForceAtPosition(wheelL.transform.up * -antiRollForce, wheelL.transform.position);
        }

        if (groundedR)
        {
            // adding the force at the position of the wheel
            carRigidBody.AddForceAtPosition(wheelR.transform.up * -antiRollForce, wheelR.transform.position);
        }
    }
}
