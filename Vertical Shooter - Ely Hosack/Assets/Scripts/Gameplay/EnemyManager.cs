using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab1, enemyPrefab2;
    private GameObject enemyPrefab;
    private GameObject enemyInstance;
    private GameManager gameManager;
    private Vector3 offset;
    private bool rushTime;
    private int enemyRange = 0;
    [SerializeField] private float maxEnemySpeed = -4.8f, minEnemySpeed = -4f;
    [SerializeField] private float maxSpawnRate = 1f, minSpawnRate = .4f;
    [SerializeField] private bool Enemy1, Enemy2, Enemy3;



    // Start is called before the first frame update
    void Start()
    {
        if (Enemy1)
        {
            enemyRange++;
        }
        if (Enemy2)
        {
            enemyRange++;
        }
        if (Enemy3)
        {
            enemyRange++;
        }
        gameManager = GameManager.singleton;
    }

    private void Update()
    {
        if(Input.GetButtonDown ("Submit"))
        {
            RushTime();
        }
    }

    // Update is called once per frame
    IEnumerator Co_SpawnEnemy()
    {
        while (gameManager.playing)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
        }
        ////Debug.Log("Stop Spawning Enemies");

    }
    private void SpawnEnemy()
    {
        

        if (Random.Range(0, enemyRange) == 2)
        {
            enemyPrefab = enemyPrefab1;
        }
        else if (Random.Range(0, enemyRange) == 1)
        {
            enemyPrefab = enemyPrefab2;
        } else
        {
            enemyPrefab = enemyPrefab1;
        }

        offset = new Vector3(Random.Range(-1f, 1f), 0);
        enemyInstance = Instantiate(enemyPrefab, transform.position + 3*offset, Quaternion.Euler(0,0, -180));
        enemyInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-.1f, .1f), Random.Range(minEnemySpeed, maxEnemySpeed));
        enemyInstance.tag = "Enemy";


        Destroy(enemyInstance, 5f);
    }

    IEnumerator Co_RushTime()
    {
        if (!rushTime)
        {
            rushTime = true;
            //Debug.Log("RushTime has been activated");
            maxEnemySpeed = -11f;
            minEnemySpeed = -10f;

            maxSpawnRate *= 2f;
            minSpawnRate *= 2f;

            //set each enemy speed to 10
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(enemy.GetComponent<Rigidbody2D>().velocity.x, Random.Range(minEnemySpeed, maxEnemySpeed));
            }
            yield return new WaitForSeconds(10f);
            //Debug.Log("10 seconds passed");
            maxEnemySpeed = -4.8f;
            minEnemySpeed = -4f;
            maxSpawnRate /= 2f;
            minSpawnRate /= 2f;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(enemy.GetComponent<Rigidbody2D>().velocity.x, Random.Range(minEnemySpeed, maxEnemySpeed));
            }
            rushTime = false;
        } 
        else
        {
            //Debug.Log("RushTime is already active");
        }
    }

    public void RushTime()
    {

        //Debug.Log("RushTime is " + rushTime.ToString());
        StartCoroutine(Co_RushTime());
    }
}
