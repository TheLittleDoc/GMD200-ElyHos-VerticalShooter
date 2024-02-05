using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInstructions : MonoBehaviour
{

    public GameObject instructionsPanel;
    public GameObject mainMenuPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInstructions()
    {
        instructionsPanel.SetActive(!instructionsPanel.activeSelf);
        mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
    }
}
