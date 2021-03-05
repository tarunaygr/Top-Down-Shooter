using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    CharacterController _charactercontroller;
    [SerializeField]
    float horizontal_ip, vertical_ip,speed;
    public Vector3 mouse_world;
    public Vector3 mouse_ip;
    public GameObject bullet_prefab;
    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    private float Bullet_speed;
    float TimetoFire,rateofFire=0.25f;
    [SerializeField]
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        _charactercontroller = GetComponent<CharacterController>();
        TimetoFire = -1;

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        Look();
        if(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Mouse0)&&Time.time>=TimetoFire)
        {
            TimetoFire = Time.time + rateofFire;
            fire();
        }
       
    }
    void movement()
    {
        horizontal_ip = Input.GetAxis("Horizontal");
        vertical_ip = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal_ip, -2.5f, vertical_ip) * speed;
        _charactercontroller.Move(velocity * Time.deltaTime);

    }
    void Look()
    {
        mouse_ip = Input.mousePosition;
        mouse_world = Camera.main.ScreenToWorldPoint(mouse_ip);
        mouse_world.y = transform.position.y;
        transform.LookAt(mouse_world, Vector3.up);
      //  transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
    }
    void fire()
    {
        GameObject fired_bullet = Instantiate(bullet_prefab, firepoint.position, Quaternion.identity);
        Rigidbody rb = fired_bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward.normalized * Bullet_speed);
    }
    public void TakeDamage()
    {
        health--;
        if(health<=0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}