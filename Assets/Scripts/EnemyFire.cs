using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField]
    GameObject bullet_prefab;
    [SerializeField]
    Transform firepoint1, firepoint2;
    [SerializeField]
    Transform target;
    float TimetoFire, RateofFire = 1f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        TimetoFire = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FaceTarget()
    {
        if (target != null)
        {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 10f);
        }
        
    }
    public void Shoot()
    {
        if(Time.time>=TimetoFire)
        {
            if (bullet_prefab == null) Debug.Log("BS");
        TimetoFire = Time.time + RateofFire;
        GameObject FiredBullet = Instantiate(bullet_prefab, firepoint1.position, Quaternion.identity);
        FiredBullet.GetComponent<Bullet>().IsFiredByEnemy();
        FiredBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 300f);
        FiredBullet = Instantiate(bullet_prefab, firepoint2.position, Quaternion.identity);
        FiredBullet.GetComponent<Bullet>().IsFiredByEnemy();
        FiredBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 300f);
        }
        

    }
}
