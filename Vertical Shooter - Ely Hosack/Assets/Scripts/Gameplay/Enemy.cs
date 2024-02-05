using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private int health = 2;

    [SerializeField] private GameObject laserPrefab;
    //dropdown for enemy type
    [SerializeField] private bool isShooter;
    [SerializeField] private bool isChaser;



    private void Start()
    {
        gameManager = GameManager.singleton;
        tag = "Enemy";
        if (isShooter)
        {
            StartCoroutine(EnemyFire());
        }
    }

    //detect collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.score += 10;
            gameManager.hits++;


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health--;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Death()
    {
        //start animation


    }

    IEnumerator EnemyFire()
    {
        while (gameManager.playing)
        {
            yield return new WaitForSeconds(Random.Range(1f, 1.2f));
            //Debug.Log("Fire");
            Fire();
        }
    }

    void Fire()
    {
        gameManager.musicHandler.PlaySoundEffect(1);
        GameObject laserInstance = Instantiate(laserPrefab, transform.position, transform.rotation);

        laserInstance.tag = "LaserEnemy";
        laserInstance.GetComponent<SpriteRenderer>().color = Color.blue;


        laserInstance.GetComponent<Rigidbody2D>().AddForce(20 * new Vector2(0,-1), ForceMode2D.Impulse);
        Destroy(laserInstance, 2f);


    }
}
