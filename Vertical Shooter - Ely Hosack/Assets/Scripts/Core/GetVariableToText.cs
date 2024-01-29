using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class getshots : MonoBehaviour
{
    private TextMeshProUGUI textObject;
    [SerializeField] private string variableName;
    // Start is called before the first frame update
    void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //set text to be variable listed in variableName
        textObject.text = variableName + ": " + GameManager.singleton.GetType().GetField(variableName).GetValue(GameManager.singleton);
    }
}
