using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 mouse_world;
    public Vector3 mouse_ip;
    public GameObject bullet_prefab;
    [SerializeField]
    private float Bullet_speed;
    [SerializeField]
    private Transform firepoint1,firepoint2;
    float TimetoFire, rateofFire = 0.25f;
    GameManager _gamemanager;
    void Start()
    {
        TimetoFire = -1;
        _gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_gamemanager.ispaused() == false)
        {
            Look();
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= TimetoFire)
            {
                TimetoFire = Time.time + rateofFire;
                fire();
            }
        }
    }
    void Look()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            mouse_world = hit.point;
        }

        mouse_world.y = transform.position.y;
        Debug.Log(mouse_world);
        Debug.Log(mouse_ip);
        transform.LookAt(mouse_world, Vector3.up);
    }
    void fire()
    {
        GameObject fired_bullet1 = Instantiate(bullet_prefab, firepoint1.position, Quaternion.identity);
        Rigidbody rb1 = fired_bullet1.GetComponent<Rigidbody>();
        rb1.AddForce(transform.forward.normalized * Bullet_speed); 
        GameObject fired_bullet2 = Instantiate(bullet_prefab, firepoint2.position, Quaternion.identity);
        Rigidbody rb2 = fired_bullet2.GetComponent<Rigidbody>();
        rb2.AddForce(transform.forward.normalized * Bullet_speed);
    }
}
