using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    [Header("Timer")]
    public TMP_Text timerValue;
    [Header("Car")]
    public GameObject car;
    [Header("Fuel")]
    public TMP_Text fuelValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fuelValue.text = car.GetComponent<CarStats>().fuelTank.ToString();
    }

    // Functions


}
