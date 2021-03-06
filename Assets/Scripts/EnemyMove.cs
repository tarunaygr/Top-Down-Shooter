using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Transform target;

    GameManager _gamemanager;
    EnemyFire gun;
    void Start()
    {
        _gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        gun = GetComponentInChildren<EnemyFire>();

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

                if (_gamemanager.ispaused() == false)
                {
                    gun.Shoot();
                    gun.FaceTarget();
                }
            }
        }

    }

}
