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
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        StartCoroutine(Co_SpawnEnemy());
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

    private void SpawnEnemy()
    {
        offset = new Vector3(Random.Range(-1f, 1f), 0);
        enemyInstance = Instantiate(enemyPrefab, transform.position + 3*offset, Quaternion.identity);
        Destroy(enemyInstance, 5f);
    }
}
