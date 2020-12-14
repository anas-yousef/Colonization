using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpaceShipMovement : MonoBehaviour
{
    public Rigidbody2D spaceShip;
    public SpriteRenderer sapeShipImage;
    public String alienTag;

    private Vector2 startLocation;
    public bool enableMovement;

    public float forwardMovementSpeed = 1f;
    public float stopMovementSpeed = 1f;
    public float sideMovementSpeed = 1f;


    void Start()
    {
        startLocation = spaceShip.position;
        // TODO: should be initialized to false
        enableMovement = false;
    }

    void FixedUpdate()
    {
        // the space ship is enabled now
        if (enableMovement)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                spaceShip.velocity = Vector3.zero;
                spaceShip.AddForce(Vector3.down * sideMovementSpeed);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                spaceShip.velocity = Vector3.zero;
                spaceShip.AddForce(Vector3.up * sideMovementSpeed);
            }

            // forward movement
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                spaceShip.velocity = Vector3.zero;
                spaceShip.AddForce(Vector3.left * forwardMovementSpeed);

                // TODO change sprite to accelerate
            }

            // stop movement
            if (Input.GetKey(KeyCode.RightArrow))
            {
                spaceShip.velocity = Vector3.zero;
                spaceShip.AddForce(-spaceShip.velocity.normalized * stopMovementSpeed);

                // TODO change sprite to move
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        // the collision was with the alien 
        if (other.gameObject.tag.Equals("Alien"))
        {
            Debug.Log("Start flying the spacehsip!");

            // kill the alien 
            Destroy(other);

            // enable the movement
            enableMovement = true;

        }

        // the collision was with other spaceship
        if (other.gameObject.tag.Equals("Spaceship"))
        {
            Debug.Log("spaceships collide! restart both");

            Hit();
        }

        // the collision was with asteroid
        if (other.gameObject.tag.Equals("Asteroid"))
        {
            Debug.Log("spaceship got hit by asteroid! restart");

            Hit();
        }

        // TODO creat
        if (other.gameObject.tag.Equals("Planet"))
        {
            Debug.Log("WICTORY!");

            // TODO change sprite to move

        }


    }

    /**
     * Got hit by an asteroid, other spaceship or a bullet
     */
    public void Hit()
    {
        // recreate the alien 
        // TODO check if the location is correct 
        GameObject alien = Instantiate(Resources.Load(alienTag)) as GameObject;

        // reposition the spaceship
        spaceShip.velocity = Vector3.zero;
        spaceShip.position = startLocation;

        // disable the spaceship movement
        enableMovement = false;
    }

}

