using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherTurret : BaseTurret
{
    public float fireRate = 2f;
    private float fireCountdown = 0;

    public float damageTurret = 10f;

    public float bombRange = 3f;

    public GameObject rocketPref;
    public Transform spawnBullet;

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
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
        GameObject rocketGO = Instantiate(rocketPref, spawnBullet.position, Quaternion.identity);

        //to do change bullet to rocker script
        Rocket rocket = rocketGO.GetComponent<Rocket>();
        if (rocket == null)
        {
            Destroy(rocketGO);
        }
        else
        {
            rocket.SetUpRocket(target, damageTurret , bombRange);
        }
    }
}
