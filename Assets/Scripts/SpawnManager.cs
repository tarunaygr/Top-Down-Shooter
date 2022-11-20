using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Enemy;
    Vector3 screenedges;
    GameManager _gamemanager;

    [SerializeField]
    private int EnemyLimit;
    Camera cam;

    void Start()
    {
         cam= Camera.main;
        StartCoroutine(SpawnEnemies());
        _gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        screenedges = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.y));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator SpawnEnemies()
    {
        Vector3 spawnpoint=new Vector3(0,0,0);
        while (true)
        {
            
            yield return new WaitForSeconds(3);
            if(GameObject.FindGameObjectsWithTag("Enemy").Length<EnemyLimit&&_gamemanager.ispaused()==false)
            {
                int seed = Random.Range(0, 4);
               // Debug.Log("seed");
                Debug.Log(seed);
                switch (seed)
                {
                    case 0: spawnpoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, cam.transform.position.y)) + new Vector3(Random.Range(0, screenedges.x), -10, 0);
                            break;
                    case 1:
                        spawnpoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, cam.transform.position.y)) + new Vector3(-10, Random.Range(0,screenedges.y), 0);
                        break;
                    case 2:
                        spawnpoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.y)) + new Vector3(10, Random.Range(0, screenedges.y), 0);
                        break;
                    case 3:
                        spawnpoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, cam.transform.position.y)) + new Vector3(Random.Range(0, screenedges.x), 10, 0);
                        break;
                }
                spawnpoint.y = 1.2f;
                //Debug.Log(spawnpoint);
                Instantiate(Enemy,spawnpoint, Quaternion.identity);
            }
            
        }
    }
}
