using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class CarMovement : MonoBehaviour
{
    // Variables
    [Header("RigidBody and Player Velocity")]
    [SerializeField] private Rigidbody carRigidBody;
    [SerializeField] private Vector3 carVelocity;
    [SerializeField] private Vector3 forwardVelocity;
    [SerializeField] private Vector3 wheelTurnValue;
    [Header("Attributes")]
    [Range(1f, 100f)]
    [SerializeField] private float speed = 25.0f;
    [Range(1f, 10f)]
    [SerializeField] private float multiplier = 5.0f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float gravity = -9.8f;
    [Header("Car Parts")]
    [SerializeField] private GameObject frontRightWheel;
    [SerializeField] private GameObject frontLeftWheel;
    [SerializeField] private GameObject rearRightWheel;
    [SerializeField] private GameObject rearLeftWheel;
    [SerializeField] private Vector3 innerWheelRotationMax = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] private Vector3 outterWheelRotationMax = new Vector3(0.0f, 0.0f, 0.0f);
    [Header("Race Stats")]
    [SerializeField] private int lapsCount;
    [SerializeField] private TMP_Text lapsCountText;

    // Start is called before the first frame update
    void Start()
    {
        carRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = carRigidBody.isGrounded;
        Debug.Log($"Acceleration: {forwardVelocity}, Wheels Turning Value: {wheelTurnValue}, Car Velocity: {carVelocity}");
    }

    // Functions
    public void Accelerate(Vector2 input)
    {
        forwardVelocity = Vector3.zero;
        //forwardVelocity.x = input.x;
        forwardVelocity.z = input.y;
        //controller.Move(transform.TransformDirection(forwardVelocity) * (speed * mutliplier) * Time.deltaTime);

        /*playervelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playervelocity.y < 0)
        {
            playervelocity.y = gravity;
        }*/
        //controller.Move(playervelocity * Time.deltaTime);
        carRigidBody.AddForce(forwardVelocity * (speed * multiplier) * Time.deltaTime);
        //Debug.Log(forwardVelocity);
    }

    public void Brake()
    {

    }

    public void TurnWheels(Vector2 input)
    {
        wheelTurnValue = Vector3.zero;
        wheelTurnValue.x = input.x;
        //wheelTurnValue.z = input.y;
        //controller.Move(transform.TransformDirection(wheelTurnValue) * (speed * mutliplier) * Time.deltaTime);

        /*playervelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playervelocity.y < 0)
        {
            playervelocity.y = gravity;
        }*/
        //controller.Move(playervelocity * Time.deltaTime);
        carRigidBody.AddForce(wheelTurnValue * (speed * multiplier) * Time.deltaTime);
        //Debug.Log(wheelTurnValue);
    }
}
