using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmpathyLevel : MonoBehaviour
{
    public Slider empathyBar;
    private int maxEmpathy = 100;

    // Start is called before the first frame update
    void Start()
    {
        empathyBar.enabled = false;
        empathyBar.value = 0;
        empathyBar.maxValue = maxEmpathy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
