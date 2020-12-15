using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemy : MonoBehaviour
{
    public Transform shot;
    public GameObject bullet;
    public string shootKey;

    public EnergyBar _energyBar;

    public SpaceShipMovementEnemy sp;


    void Update()
    {
        if (Input.GetButtonDown(shootKey))
        {



            //check if able to add shot
            if (_energyBar.canShoot() && sp.enableMovement)
            {
                // add shoot
                _energyBar.AddShoot();
                shoot();
            }
        }
    }

    void shoot()
    {
        // Create a new bullet game object
        Instantiate(bullet, shot.position, shot.rotation);
        SoundManagerScript.PlaySound("LaserShot");
    }
}
