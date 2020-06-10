using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem particles;
    
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
            Instantiate(particles);
            Debug.Log("particles " + particles);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        
    }
    
}
