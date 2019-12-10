using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBars : MonoBehaviour
{
    public Slider empathyBar;
    public Slider powerBar;
    public Slider charismaBar;
    public Slider strategyBar;

    public bool isEmpathyFull()
    {
        return ((int)empathyBar.value == (int)empathyBar.maxValue);
    }

    public void updateEmpathy(int change)
    {
        empathyBar.value += change;

        if(empathyBar.value > empathyBar.maxValue)
        {
            empathyBar.value = empathyBar.maxValue;
        }
        else if(empathyBar.value < 0)
        {
            empathyBar.value = 0;
        }
    }

    public void updatePower(int change)
    {
        powerBar.value += change;

        if (powerBar.value > powerBar.maxValue)
        {
            powerBar.value = powerBar.maxValue;
        }
        else if (powerBar.value < 0)
        {
            powerBar.value = 0;
        }
    }

    public void updateCharisma(int change)
    {
        charismaBar.value += change;

        if (charismaBar.value > charismaBar.maxValue)
        {
            charismaBar.value = charismaBar.maxValue;
        }
        else if (charismaBar.value < 0)
        {
            charismaBar.value = 0;
        }
    }

    public void updateStrategy(int change)
    {
        strategyBar.value += change;

        if (strategyBar.value > strategyBar.maxValue)
        {
            strategyBar.value = strategyBar.maxValue;
        }
        else if (strategyBar.value < 0)
        {
            strategyBar.value = 0;
        }
    }
}
