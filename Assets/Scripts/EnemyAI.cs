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
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void LateUpdate()
    {
        agent.SetDestination(target.position);
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
            //Shoot();

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
        GameObject FiredBullet=Instantiate(bullet_prefab, transform.position, Quaternion.identity);
        FiredBullet.GetComponent<Bullet>().IsFiredByEnemy();
        FiredBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10f);

    }
}
