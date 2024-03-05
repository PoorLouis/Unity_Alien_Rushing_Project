using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public EnemyController targetEnemy;
    public Transform target;
    public float range = 5f;
    public int sellPrice;

    public Transform pathToRotate;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        StartCoroutine(UpdateTarget());
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (MainGameController.instance.isEndGame)
        {
            return;
        }

        if (target == null) 
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        dir.y = 0f; 
        Vector3 smoothDir = Vector3.Lerp(transform.rotation.eulerAngles, dir, 0.001f);
        pathToRotate.rotation = Quaternion.LookRotation(smoothDir);
    }

    private IEnumerator UpdateTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            GameObject[] enemise =  GameObject.FindGameObjectsWithTag("Enemy");

            float shortestDistance = float.MaxValue;
            GameObject nearestEnemy = null;

            for(int i = 0; i< enemise.Length; i++)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemise[i].transform.position);
                if(distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemise[i];
                }
            }

            if(nearestEnemy != null && shortestDistance < range)
            {
                target = nearestEnemy.transform;
                targetEnemy = target.GetComponent<EnemyController>();
            }
            else
            {
                target = null;
            }
        }
    }

    private void OnDrawGizmos() 
    {        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , range);
    }
}
