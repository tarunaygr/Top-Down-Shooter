using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _charactercontroller;
    [SerializeField]
    float horizontal_ip, vertical_ip,speed;
    [SerializeField]
    private int health;
    GameManager _gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        _gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _charactercontroller = GetComponent<CharacterController>();

        _gamemanager.PlayerHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(_gamemanager.ispaused()==false)
        {
            movement();
        }
        
       
    }
    void movement()
    {
        horizontal_ip = Input.GetAxis("Horizontal");
        vertical_ip = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal_ip, -2.5f, vertical_ip) * speed;
        _charactercontroller.Move(velocity * Time.deltaTime);

    }


    public void TakeDamage()
    {
        health--;
        _gamemanager.PlayerHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}