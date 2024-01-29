using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score, lives, world = 1, level = 0, shots = 0, hits = 0, health = 10;
    public bool gameOver;
    public float progress, accuracy;
    public double time;

    public static GameManager singleton;

    public static float playerSpeed = 10f;
    public static float enemySpeed = 5f;
    public static float laserSpeed = 20f;
    public static float laserLife = 2f;
    public static float enemySpawnRateMax = 2f;
    public static float enemySpawnRateMin = .8f;
    public static float maxX = 2.5f;
    public static float maxY = 1f;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        tag= "GameManager";
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GameOver()
    {
        gameOver = true;

        return true;
    }

    public bool ResetGame()
    {
        score = 0;
        lives = 3;
        gameOver = false;
        health = 100;
        progress = 0;
        time = 0;

        world = 1;
        level = 1;

        return true;
    }

    public void StartGame ()
    {
        time = 0;
    }

    public void Shot()
    {
        shots++;
    }
}
