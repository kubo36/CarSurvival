using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f;




    float yRotation = 0f;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -20f, 9f);
        transform.localRotation = Quaternion.Euler(0f, yRotation, xRotation);

        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, -40f, 40f);
        transform.localRotation = Quaternion.Euler(0f, -yRotation, xRotation);


    }
}
