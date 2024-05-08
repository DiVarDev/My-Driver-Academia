using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    // Variables
    public int fuelTank = 100;
    public int fuelCanister = 4;
    public int barrelFuelLoss = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // On Collision
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Fuel"))
        {
            Destroy(other.gameObject);
            if (fuelTank < 100)
            {
                fuelTank += fuelCanister;
            }
        }

        if (other.transform.tag.Equals("Barrel"))
        {
            Destroy(other.gameObject);
            fuelTank -= barrelFuelLoss;
        }
    }
}
