using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject focus;
    public float distance = 5f;
    public float height = 2f;
    public float dampening = 1f;
    public float distance2 = 0f;
    public float height2 = 0f;
    public float width = 0f;

    private int camMode = 0;

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.C))
        {
            camMode = (camMode + 1) % 2;
        }

        switch(camMode){
            case 1:
                // Camera inside of the car
                transform.position = focus.transform.position + focus.transform.TransformDirection(new Vector3(width, height2, distance2));
                transform.rotation = focus.transform.rotation;
                break;
            default:
                //  Camera following Gameobject
                transform.position = Vector3.Lerp(transform.position, focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, height, -distance)), dampening * Time.deltaTime);
                transform.LookAt(focus.transform);
                break;
        }
        


    }
}
