using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetVariableToSlider : MonoBehaviour
{
    private Slider slider;
    private float thisValue;
    [SerializeField] private string variableName;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        ////Debug.Log(GameManager.singleton.GetType().GetField(variableName).GetValue(GameManager.singleton));
        //set slider value to be variable listed in variableName
        if (slider.wholeNumbers)
        {
            slider.value = (int)GameManager.singleton.GetType().GetField(variableName).GetValue(GameManager.singleton);
        }
        else
        {
            slider.value = (float)GameManager.singleton.GetType().GetField(variableName).GetValue(GameManager.singleton);
        }
    }
}
