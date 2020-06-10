using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Animator animator;
    public bool isClicked = false;
    [SerializeField]
    private Text chestText;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isClicked)
        {
            OpenChest();
            
        }
        
    }

    public void OpenChest()
    {
        Debug.Log("F pressed");
        animator.SetBool("IsClicked", true);
        isClicked = true;
    }

    private void OnTriggerEnter(Collider other)
    {


        if (isClicked == false)
        {
            if (other.name == "Tocus")
            {
                chestText.enabled = true;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Tocus")
        {
            chestText.enabled = false;
        }
    }
}
