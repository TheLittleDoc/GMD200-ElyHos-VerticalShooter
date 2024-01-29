using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.singleton;
        tag = "Enemy";
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
}
