using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : BaseTurret
{
    public float fireRate = 2f;
    private float fireCountdown = 0;

    public float damageTurret = 10f;

    public GameObject bulletPref;
    public Transform spawnBullet;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        fireCountdown -= Time.deltaTime;

        base.Update();

        if (target == null)
        {
            return;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
    }

    public void Shoot()
    {        
        GameObject bulletGO = Instantiate(bulletPref, spawnBullet.position, Quaternion.identity);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet == null)
        {
            Destroy(bulletGO);
        }
        else
        {
            bullet.SetUpBullet(target, damageTurret);
        }
    }
}
