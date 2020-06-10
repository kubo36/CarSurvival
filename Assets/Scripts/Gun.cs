using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public int range = 100;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject projectile;
       
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            muzzleFlash.Play();
            FindObjectOfType<AudioManager>().Play("Gun Shot");
            Shoot();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            muzzleFlash.Stop();
        }

    }

    void Shoot()
    {

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Enemy target = hit.transform.GetComponent<Enemy>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
