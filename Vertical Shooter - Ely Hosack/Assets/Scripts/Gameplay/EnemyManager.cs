using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject enemyInstance;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Co_SpawnEnemy());
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
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(.8f, 1.9f));
        }

    }
    public List<GameObject> enemies = new List<GameObject>();
    private void SpawnEnemy()
    {
        offset = new Vector3(Random.Range(-1f, 1f), 0);
        enemyInstance = Instantiate(enemyPrefab, transform.position + 3*offset, Quaternion.Euler(0,0, -180));
        enemyInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-.1f, .1f), Random.Range(-4f, -4.8f));
        enemies.Add(enemyInstance);


        Destroy(enemyInstance, 5f);
        enemies.Remove(enemyInstance);
    }

    IEnumerator Co_RushTime()
    {
        for (int i = 0, n = enemies.Count; i < n; i++)
        {
            enemies[i].GetComponent<Rigidbody2D>().velocity *= 2;
            Debug.Log(enemies[i].name);
        }
        yield return new WaitForSeconds(15f);
        for (int i = 0, n = enemies.Count; i < n; i++)
        {
            enemies[i].GetComponent<Rigidbody2D>().velocity /= 2;
        }

    }

    public void RushTime()
    {
        Debug.Log("RushTime");
        StartCoroutine(Co_RushTime());
    }
}
