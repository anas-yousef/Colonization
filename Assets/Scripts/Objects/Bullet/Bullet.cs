using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed = 20f;
    public Rigidbody2D rb;
    public float timer = 1f;
    public string enemyTagAlien;
    public string enemyTagSpaceship;
    public string enemyName;
    public int dir;


    void Start()
    {
        // TODO add delta time 
        // TODO need to add right to the other bullet
        //if (dir == 0)
        //{
        //    rb.AddForce(Vector3.left * bulletspeed);
        //}
        //if(dir == 1)
        //{
        //    rb.AddForce(Vector3.right * bulletspeed);
        //}
        
    }

    private void FixedUpdate()
    {

        if (dir == 0)
        {
            rb.AddForce(Vector3.left * bulletspeed);
        }
        if (dir == 1)
        {
            rb.AddForce(Vector3.right * bulletspeed);
        }

        // make the bullet disappear after a while
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag.Equals(enemyTagAlien) && gameObject)
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

        if (hitInfo.gameObject.tag.Equals(enemyTagSpaceship) && gameObject)
        {

            //GameObject alien = Instantiate(Resources.Load(enemyName)) as GameObject;

            Debug.Log("BOOM: the bullet hit the other player");
            if (enemyTagSpaceship.Equals("Spaceship2"))
            {
               AlienEnemy enemy = hitInfo.GetComponent<AlienEnemy>();
                if (enemy != null)
                {
                    enemy.Hit();
                }
            }
            if (enemyTagSpaceship.Equals("Spaceship1"))
            {
                AlienController enemy = hitInfo.GetComponent<AlienController>();
                if (enemy != null)
                {
                    enemy.Hit();
                }
            }    
            
            //if (enemy != null)
            //{
            //    enemy.Hit();
            //}

            // destroy the bullet
            Destroy(gameObject);
        }
    }
}
