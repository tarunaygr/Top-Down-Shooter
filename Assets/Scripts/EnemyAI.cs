using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Transform target;
    [SerializeField]
    GameObject bullet_prefab;
    Transform firepoint;
    float TimetoFire, RateofFire=1f;
    GameManager _gamemanager;
    void Start()
    {
        _gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        TimetoFire = 3f;
        firepoint = transform.GetChild(1).transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target!=null)
        {
            agent.SetDestination(target.position);
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                if (TimetoFire <= Time.time&&_gamemanager.ispaused()==false) 
                Shoot();

            }
        }

    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 10f);
    }
    void Shoot()
    {
        TimetoFire = Time.time + RateofFire;
        GameObject FiredBullet=Instantiate(bullet_prefab, firepoint.position, Quaternion.identity);
        FiredBullet.GetComponent<Bullet>().IsFiredByEnemy();
        FiredBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 300f);

    }
}
