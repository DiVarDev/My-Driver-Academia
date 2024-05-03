using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    // Variables
    private InputActions input;
    private InputActions.DriverActions driver;

    private CarMovement carMovement;

    void Awake()
    {
        input = new InputActions();
        driver = input.Driver;
        carMovement = GetComponent<CarMovement>();

        //driverActions.Throttle.performed += ctx => carMovement.Accelerate();

    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Will tell the CarMovement to move using the value from the movement action on MyInputActions
        carMovement.Accelerate(driver.Movement.ReadValue<Vector2>());
        carMovement.TurnWheels(driver.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        
    }

    void OnEnable()
    {
        driver.Enable();
    }

    void OnDisable()
    {
        driver.Disable();
    }
}
