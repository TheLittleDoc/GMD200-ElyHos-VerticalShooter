using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleton;
    }

    // Update is called once per frame
    public void LoadScene()
    {
        if (sceneName == "SampleScene")
        {
            gameManager.StartGame();
        }
        else if (sceneName == "MainMenu")
        {
            gameManager.Restart();
        }
    }
}
