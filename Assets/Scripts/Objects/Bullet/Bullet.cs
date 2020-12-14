using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed = 0.5f;
    public Rigidbody2D rb;
    public float timer = 1f;
    public string enemyTag;


    void Start()
    {
        // TODO add delta time 
        rb.velocity = transform.right * bulletspeed;
    }

    private void Update()
    {
        // make the bullet disappear after a while
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag.Equals(enemyTag) && gameObject)
        {
            
            Debug.Log("BOOM: the bullet hit the other player");
            SpaceShipMovement enemy = hitInfo.GetComponent<SpaceShipMovement>();
            if (enemy != null)
            {
                enemy.Hit();
            }

            // destroy the bullet
            Destroy(gameObject);
        }
    }
}
