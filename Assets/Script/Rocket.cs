using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Transform target;

    public float speed = 20f;
    public float damage = 10f;
    public float bombRange = 3f;

    public void SetUpRocket(Transform mTarget, float mDamage , float mBombRange)
    {
        target = mTarget;
        damage = mDamage;
        bombRange = mBombRange;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;

        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    private void HitTarget()
    {
        Collider[] allObj = Physics.OverlapSphere(target.position, bombRange);

        for(int i =0; i < allObj.Length; i++)
        {
            EnemyController enemy = allObj[i].GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        // To Do : ลด HP Enemy Target       
        Destroy(gameObject);
    }
}
