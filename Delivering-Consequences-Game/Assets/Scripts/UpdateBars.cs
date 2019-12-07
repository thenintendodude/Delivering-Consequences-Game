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

    public void updateEmpathy(int change)
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
    }
}
