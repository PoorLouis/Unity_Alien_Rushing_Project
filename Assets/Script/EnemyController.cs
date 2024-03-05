using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float hp = 100f; 
    private float hpDamge = 0f; 

    public Transform[] path; 
    public float speed = 5;
    private float speedMultiply = 1f;
    private float slowTimer = 0f;

    private int targetWatpointIndex; 

    public Image hpBar;

    public int goldDrop = 50;
    public int life = 5;

    public void Setup(Transform[] waypoints) 
    {
        MainGameController.instance.enemyCount++;
        path = waypoints;
        transform.position = path[0].position;
        targetWatpointIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(MainGameController.instance.isEndGame)
        {
            Destroy(gameObject);
        }

        Vector3 dir = path[targetWatpointIndex].position - transform.position; 
        transform.Translate(dir.normalized * speed * speedMultiply * Time.deltaTime, Space.World);
        if(dir.magnitude < 0.1f)
        {
            targetWatpointIndex++;

            if (targetWatpointIndex >= path.Length)
            {
                MainGameController.instance.life--;
                Destroy(gameObject);
            }

        }

        if (slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;
        }
        else
        {
            speedMultiply = 1f;
        }
    }

    public void TakeDamage(float damage)
    {
        hpDamge += damage;

        hpBar.fillAmount = (hp-hpDamge) / hp;
        if(hpDamge >= hp)
        {
            MainGameController.instance.gold += goldDrop;
            MainGameController.instance.enemyCount--;
            Destroy(gameObject);
        }
    }

    public void Slow(float slowPCT)
    {
        speedMultiply = 1f - slowPCT;
        slowTimer = 1f;
    }


}
