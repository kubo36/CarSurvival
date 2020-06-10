using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    
    


    public virtual void ChangeText(float speed)
    {
        text.text = Mathf.Clamp(Mathf.Round(speed), 0f, 1000f) + " km/h";
    }

    

   
}
