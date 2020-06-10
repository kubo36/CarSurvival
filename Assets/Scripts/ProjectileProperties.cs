using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.transform;

        //Position of the target
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement of the bullet toward target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //Checking if the bullet reach the target
        if(transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Tocus")
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    } 
}
