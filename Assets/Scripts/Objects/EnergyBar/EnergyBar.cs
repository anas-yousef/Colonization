using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    // change to private
    private bool _canShootVar = true;

    public float startEnergy = 1f;
    public float decreaseEachShoot = .2f;
    public float addEachSecond = .003f;
    public float stopShootingUnder = .1f;
    public float startShootingAbove = .9f;

    private Image barImage;

    private void Awake()
    {
        // creating the bar 
        barImage = transform.Find("Bar").GetComponent<Image>();
        barImage.fillAmount = startEnergy; 
    }

    public void Update()
    {
        // Need to recharge
        if (barImage.fillAmount <= stopShootingUnder)
        {
            Debug.Log("Too much shooting, need to regain power");
            _canShootVar = false;
        }
        
        // finished recharging
        if (!_canShootVar && barImage.fillAmount >= startShootingAbove)
        {
            Debug.Log("Finished recharging");
            _canShootVar = true;
        }
        
        // need to fill energy
        if (barImage.fillAmount < 1)
        {
            // TODO there is a problem with using Time.deltaTime
            barImage.fillAmount += addEachSecond;
        }
    }

    public bool canShoot()
    {
        return _canShootVar; 
    }

    public void AddShoot()
    {
        // TODO there is a problem with using Time.deltaTime
        barImage.fillAmount -= decreaseEachShoot;
    }
}
