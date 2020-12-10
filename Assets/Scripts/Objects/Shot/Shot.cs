using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform shot;
    public GameObject bullet;
    public string shootKey;

    public EnergyBar _energyBar;

    public SpaceShipMovement sp;
    

    void Update()
    {
        // TODO should be changed to get the enter from the player?
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
    }

}
