using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    // Variables
    public int fuelTank = 100;
    public int fuelCanister = 4;
    public int barrelFuelLoss = 2;
    [Header("Sound Manager")]
    public AudioSource soundManagerAudioSource;
    public AudioClip hitFuelCanSound;
    public AudioClip hitBarrelSound;
    public AudioClip triggeredCheckpoint;
    public AudioClip triggeredFinalCheckpoint;

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
            soundManagerAudioSource.PlayOneShot(hitFuelCanSound);
            if (fuelTank < 100)
            {
                fuelTank += fuelCanister;
            }
        }


        if (other.transform.tag.Equals("Barrel"))
        {
            Destroy(other.gameObject);
            soundManagerAudioSource.PlayOneShot(hitBarrelSound);
            fuelTank -= barrelFuelLoss;
        }
    }
}
