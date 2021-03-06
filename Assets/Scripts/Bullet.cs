using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    bool firedByEnemy=false;
    [SerializeField]
    GameManager _gamemanager;
    void Start()
    {
        _gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy")&&!firedByEnemy)
        {
            Destroy(collision.gameObject);
            _gamemanager.EnemyKilled();
            Destroy(this.gameObject);
        }
        if(collision.transform.CompareTag("Player")&&firedByEnemy==true)
        {
            collision.transform.GetComponent<PlayerMovement>().TakeDamage();
            Destroy(gameObject);
        }
        if(collision.transform.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    public void IsFiredByEnemy()
    {
        firedByEnemy = true;
    }
}
