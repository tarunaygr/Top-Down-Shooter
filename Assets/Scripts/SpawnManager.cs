using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Enemy;
    Vector3 screenedges;
    [SerializeField]
    private int EnemyLimit;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        screenedges = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
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
            if(GameObject.FindGameObjectsWithTag("Enemy").Length<EnemyLimit)
            {
                int seed = Random.Range(0, 4);
                Debug.Log(seed);
                switch (seed)
                {
                    case 0: spawnpoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)) + new Vector3(Random.Range(0, screenedges.x), -5, 0);
                            break;
                    case 1:
                        spawnpoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)) + new Vector3(-5, Random.Range(0,screenedges.y), 0);
                        break;
                    case 2:
                        spawnpoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)) + new Vector3(5, Random.Range(0, screenedges.y), 0);
                        break;
                    case 3:
                        spawnpoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)) + new Vector3(Random.Range(0, screenedges.x), 5, 0);
                        break;
                }
                spawnpoint.y = 1.2f;
                Debug.Log(spawnpoint);
                Instantiate(Enemy,spawnpoint, Quaternion.identity);
            }
            
        }
    }
}
