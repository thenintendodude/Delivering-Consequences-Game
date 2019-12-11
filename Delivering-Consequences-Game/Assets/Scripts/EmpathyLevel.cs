using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmpathyLevel : MonoBehaviour
{
    public Slider empathyBar;
    public Slider powerBar;
    public Slider charismaBar;
    public Slider strategyBar;
    private int maxEmpathy = 70;
    private int maxPower = 100;
    private int maxCharisma = 100;
    private int maxStrategy = 100;

    // Start is called before the first frame update
    void Start()
    {
        empathyBar.enabled = false;
        powerBar.enabled = false;
        charismaBar.enabled = false;
        strategyBar.enabled = false;
        empathyBar.value = 0;
        empathyBar.maxValue = maxEmpathy;
        powerBar.value = 100;
        powerBar.maxValue = maxPower;
        charismaBar.value = 50;
        charismaBar.maxValue = maxCharisma;
        strategyBar.value = 0;
        strategyBar.maxValue = maxStrategy;
    }
}

