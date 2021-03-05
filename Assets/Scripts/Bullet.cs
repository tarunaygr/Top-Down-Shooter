using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    bool firedByEnemy=false;
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position += transform.forward*Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy")&&!firedByEnemy)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if(collision.transform.CompareTag("Player")&&firedByEnemy==true)
        {
            collision.transform.GetComponent<player>().TakeDamage();
            Destroy(gameObject);
        }
    }
    public void IsFiredByEnemy()
    {
        firedByEnemy = true;
    }
}
