using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMovment : MonoBehaviour
{
    [SerializeField]
     public int PlayerNumber;

    [SerializeField]
    public float Speed;
    [SerializeField]
    public float TurnSpeed;
    [SerializeField]
    public float VerticalSpeed;

    [SerializeField]
    float howLongStunned;

    private Rigidbody Rigidbody;

    public static int PassingNumber;


    private float MovementInputValue;
    private float TurnInputValue;
    private float VerticalInputValue;


    public float StunedSpeed;
    public float StunedTurnSpeed;
    public float StunedVerticalSpeed;

    private  bool canMove = true;

    private string MovementAxisName;
    private string TurnAxisName;
    private string PitchAxisName;

    private new ParticleSystem[] particleSystem;

    // Use this for initialization
    void Start()
    {
        MovementAxisName = "Vertical" + PlayerNumber;
        TurnAxisName = "Horizontal" + PlayerNumber;
        PitchAxisName = "Pitch" + PlayerNumber;
        PassingNumber = PlayerNumber;
    }


    void Update()
    {
        MovementInputValue = Input.GetAxis(MovementAxisName);
        TurnInputValue = Input.GetAxis(TurnAxisName);
        VerticalInputValue = Input.GetAxis(PitchAxisName);
    }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {


        MovementInputValue = 0f;
        TurnInputValue = 0f;
        VerticalInputValue = 0f;

        particleSystem = GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < particleSystem.Length; ++i)
        {
            particleSystem[i].Play();
        }
    }

    private void OnDisable()
    {

    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        allowedToMove();

    }

    public  void Hit()
    {
        canMove = false;
    }



    private IEnumerator stunCountdown()
    {

        //isFirstTImeBeingStunned = false;

        yield return new WaitForSecondsRealtime(howLongStunned);
        //isFirstTImeBeingStunned = false;
        canMove = true;
        Debug.Log("I am no longer stunned");



    }
    private void allowedToMove()
    {
        if (canMove == true)
        {
            Move();
            Turn();
            Vertical();
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            for (int i = 0; i < particleSystem.Length; ++i)
            {
                particleSystem[i].Play();
            }
        }

        else if (canMove == false)
        {
            MovementInputValue = 0f;
            TurnInputValue = 0f;
            VerticalInputValue = 0f;

            gameObject.GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine(stunCountdown());
            for (int i = 0; i < particleSystem.Length; ++i)
            {
                particleSystem[i].Stop();
            }
        }

    }

    private void Vertical()
    {
        float pitch = VerticalInputValue * TurnSpeed * Time.deltaTime;

        Quaternion pitchRotation = Quaternion.Euler(pitch, 0f, 0f);


        Rigidbody.MoveRotation(Rigidbody.rotation * pitchRotation);


    }

    private void Turn()
    {
        float turn = TurnInputValue * TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);


        Rigidbody.MoveRotation(Rigidbody.rotation * turnRotation);
    }

    private void Move()
    {
        Vector3 movement = transform.forward * MovementInputValue * Speed * Time.deltaTime;

        Rigidbody.MovePosition(Rigidbody.position + movement);
    }
}

