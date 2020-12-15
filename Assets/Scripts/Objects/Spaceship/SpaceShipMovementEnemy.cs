using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceShipMovementEnemy : MonoBehaviour
{
    public Rigidbody2D spaceShip;
    public SpriteRenderer spaceShipImage;
    public String alienTag;

    private Vector2 startLocation;
    public bool enableMovement;

    public float forwardMovementSpeed = 10f;
    public float sideMovementSpeed = 10f;

    private readonly string horizontal = "Horizontal";
    private readonly string vertical = "Vertical";


    // images
    private Sprite spaceshipStaticSprite;
    private Sprite spaceshipMoveSprite;

    public String nameStaticImage;
    public String nameMoveImage;




    void Start()
    {
        startLocation = spaceShip.position;
        enableMovement = false;

        spaceshipStaticSprite = Resources.Load(nameStaticImage, typeof(Sprite)) as Sprite;
        spaceshipMoveSprite = Resources.Load(nameMoveImage, typeof(Sprite)) as Sprite;

    }

    void FixedUpdate()
    {

        // the space ship is enabled now
        if (enableMovement)
        {

            float posX = Input.GetAxisRaw(vertical);
            float posY = Input.GetAxisRaw(horizontal);

            if (Mathf.Abs(spaceShip.position.y) > (CanvasDimensions.canvasHeight / 2))
            {
                Debug.Log("spaceship got out of the canvas");
                Hit();
            }

            if (Mathf.Abs(spaceShip.position.x) > (CanvasDimensions.canvasWidth / 2))
            {
                Debug.Log("spaceship got out of the canvas");
                Hit();
            }


            if (posX != 0f && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            {
                spaceShip.AddForce(posX * Vector2.up * forwardMovementSpeed);
            }

            if (posY != 0f && Input.GetKey(KeyCode.D))
            {
                spaceShip.AddForce(posY * Vector2.right * sideMovementSpeed);
            }

            if (posX == 0 && posY == 0)
            {
                spaceShip.velocity = Vector2.zero;
                spaceShip.angularVelocity = 0f;
            }


            //if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    //spaceShip.velocity = Vector3.zero;
            //    spaceShip.AddForce(Vector3.down * sideMovementSpeed);

            //    spaceShip.velocity = Vector3.zero;
            //}

            //else if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    //spaceShip.velocity = Vector3.zero;
            //    spaceShip.AddForce(Vector3.up * sideMovementSpeed);

            //    spaceShip.velocity = Vector3.zero;
            //}

            //// forward movement
            //else if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    //spaceShip.velocity = Vector3.zero;
            //    spaceShip.AddForce(Vector3.left * forwardMovementSpeed);

            //    spaceShipImage.sprite = spaceshipMoveSprite;
            //}

            //else
            //{
            //    spaceShipImage.sprite = spaceshipStaticSprite;
            //    spaceShip.velocity = Vector3.zero;
            //}
        }
        else
        {
            spaceShip.velocity = Vector2.zero;
            spaceShip.angularVelocity = 0f;
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
        if (other.gameObject.tag.Equals("Spaceship1"))
        {
            Debug.Log("Spaceships collide! restart both");

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
            Debug.Log("VICTORY!");

            SceneManager.LoadScene(3);
            // TODO change sprite to move

        }

        if (other.gameObject.tag.Equals("Shot"))
        {
            Debug.Log("spaceship got hit by asteroid! restart");

            Hit();
        }

        if (other.gameObject.tag.Equals("Moon"))
        {
            Debug.Log("Spaceship got hit by Moon! restart");

            Hit();
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
        spaceShip.position = startLocation;
        spaceShip.velocity = Vector2.zero;
        spaceShip.angularVelocity = 0f;
        

        // disable the spaceship movement
        enableMovement = false;
    }

}
