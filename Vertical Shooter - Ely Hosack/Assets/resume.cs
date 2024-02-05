using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resume : MonoBehaviour
{
    // Start is called before the first frame update
    public void ResumeButton()
    {
        GameManager.singleton.Unpause();
    }
    public void MainMenuButton()
    {
        GameManager.singleton.Restart();
    }
}
