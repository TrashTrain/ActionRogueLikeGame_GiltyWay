using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRateItem : Item
{
    public float shootingRate = 0.2f;
    public float plusShootingRateTime = 5f;
    
    public GunController gun; 

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            StartCoroutine(IncreaseShootingRate(gun));

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator IncreaseShootingRate(GunController gun)
    {
        float playerShootingRate = gun.maxRate;
        gun.maxRate += shootingRate;
        
        yield return new WaitForSeconds(plusShootingRateTime);

        gun.maxRate = playerShootingRate;
        Destroy(gameObject);
    }
}
