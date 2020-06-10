using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public List<Light> lights;
    public List<GameObject> brakeLights;

    // turns on the headlights when they are off and vise versa
    public virtual void ToggleHeadlights()
    {
        foreach(Light light in lights)
        {
            light.intensity = light.intensity == 0 ? 2 : 0;
        }
    }
    // Changing material of the brakelights
    public virtual void ToggleBrakelightsOn()
    {
        foreach(GameObject bl in brakeLights)
        {
            bl.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.5f, 0.111f, 0.111f));
        }
    }
    // Changing material of the brakelights
    public virtual void ToggleBrakelightsOff()
    {
        foreach (GameObject bl in brakeLights)
        {
            bl.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 0f, 0f));
        }
    }
}
