﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmpathyLevel : MonoBehaviour
{
    public Slider empathyBar;
    public Slider powerBar;
    public Slider charismaBar;
    public Slider strategyBar;
    private int maxEmpathy = 100;
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
        powerBar.value = 0;
        powerBar.maxValue = maxPower;
        charismaBar.value = 0;
        charismaBar.maxValue = maxCharisma;
        strategyBar.value = 0;
        strategyBar.maxValue = maxStrategy;
    }

    /*public void updateEmpathy(int change)
    {
        empathyBar.value += change;
    }

    public void updatePower(int change)
    {
        powerBar.value += change;
    }

    public void updateCharisma(int change)
    {
        charismaBar.value += change;
    }

    public void updateStrategy(int change)
    {
        strategyBar.value += change;
    }*/
}

