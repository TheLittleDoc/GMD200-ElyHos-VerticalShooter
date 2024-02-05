using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const float MaxPlasma = 200f;
    public int score, lives, world = 1, level = 0, shots = 0, hits = 0, health = 10;
    public bool gameOver = false, playing = false;
    public float progress, accuracy, plasma;
    public double time;

    public List<Level[]> worlds;


    public static GameManager singleton;

    public static float playerSpeed = 10f;
    public static float enemySpeed = 5f;
    public static float laserSpeed = 20f;
    public static float laserLife = 2f;
    public static float enemySpawnRateMax = 2f;
    public static float enemySpawnRateMin = .8f;
    public static float maxX = 2.5f;
    public static float maxY = 1f;

    private GameObject canvas;
    private GameObject gameOverObject;
    private GameObject HUD;
    private GameObject pauseObject;

    private static readonly string GAMEPLAY_SCENE = "SampleScene";
    private Coroutine plasmaComputer;
    private Coroutine enemySpawner;

    public MusicHandler musicHandler;
    private Coroutine timestop;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        tag= "GameManager";
        musicHandler = GetComponent<MusicHandler>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playing)
        {
            if(pauseObject != null)
            {
                pauseObject.SetActive(false);
            }
            if ((health <= 0))
            {
                GameOver();
            }
            else if (plasma <= 0 && playing)
            {
                Finish();
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (playing)
                {
                    Pause();
                }
                else
                {
                    Unpause();
                }
            }
        }
        
    }

    public void Pause()
    {
        if(pauseObject != null)
        {
            pauseObject.SetActive(true);
        }
        else
        {
            Debug.Log(GameObject.FindWithTag("Pause"));
            pauseObject = GameObject.FindWithTag("Pause");
            pauseObject.SetActive(true);
        }
        Time.timeScale = 0;
        playing = false;
    }

    public void Unpause()
    {
        pauseObject = GameObject.FindWithTag("Pause");
        pauseObject.SetActive(false);
        Time.timeScale = 1;
        playing = true;
    }

    public bool GameOver()
    {
        pauseObject = null;
        plasmaComputer = null;
        gameOver = true;
        //deactivate input
        //display game over screen
        HUD = GameObject.Find("HUD");
        canvas = GameObject.FindGameObjectWithTag("UICanvas");
        gameOverObject = canvas.transform.Find("GameOver").gameObject;
        HUD = canvas.transform.Find("HUD").gameObject;
        gameOverObject.SetActive(true);
        HUD.SetActive(false);
        //disconnect canvas from reference
        musicHandler.StopMusic();
        
        //disable player input
        playing = false;
        //destroy enemy manager
        FindAnyObjectByType<EnemyManager>().StopCoroutine("Co_SpawnEnemy");



        return true;
    }

    public void Finish()
    {
        plasmaComputer = null;
        gameOver = true;
        playing = false;
        canvas = GameObject.FindGameObjectWithTag("UICanvas");
        HUD = canvas.transform.Find("HUD").gameObject;
        HUD.SetActive(false);
        Level finishedLevel = new(health, shots, hits, 50);
        playing = false;
        FindAnyObjectByType<EnemyManager>().StopCoroutine("Co_SpawnEnemy");
    }

    


    public bool ResetGame()
    {
        score = 0;
        lives = 3;
        gameOver = false;
        health = 10;
        progress = 0;
        time = 0;
        plasma = MaxPlasma;
        world = 1;
        level = 1;
        if(timestop != null)
        {
            StopCoroutine(timestop);
        }
        return true;
    }

    public void StartGame ()
    {
        ResetGame();
        SceneManager.LoadScene(GAMEPLAY_SCENE);
    }

    

    public void Shot()
    {
        shots++;
    }

    public void Restart()
    {
        ResetGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void Playing()
    {
        plasma = MaxPlasma;
        playing = true;
        plasmaComputer = StartCoroutine(DrainPlasma());
        enemySpawner = FindAnyObjectByType<EnemyManager>().StartCoroutine("Co_SpawnEnemy");
    }
    

    IEnumerator DrainPlasma()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            plasma -= .1f;
        }
    }

}


