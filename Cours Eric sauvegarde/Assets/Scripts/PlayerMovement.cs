using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [Header("Links")] public Rigidbody Rigidbody;

    [Header("Movement Variables")] [SerializeField]
    private float speed;

    [SerializeField] private float maxSpeed;
    
    [SerializeField] private float jumpSpeed;
    
    [HideInInspector]
    public bool canMove = true;

    private void Start()
    {
        GameplayManager.SINGLETON.PM = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A )&& canMove)
        {
            consumeInput(KeyCode.A);
        }
        if (Input.GetKey(KeyCode.D)&& canMove)
        {
            consumeInput(KeyCode.D);
        }

        if (Input.GetKeyDown(KeyCode.Space)&& canMove)
        {
            consumeInput(KeyCode.Space);
        }
    }

    private void consumeInput(KeyCode key)
    {
        if (Math.Abs(Rigidbody.velocity.x) < Math.Abs(maxSpeed))
        {
            if (key == KeyCode.A)
            {
                Rigidbody.AddForce(new UnityEngine.Vector3(-speed,0,0));
            }
            if (key == KeyCode.D)
            {
                Rigidbody.AddForce(new UnityEngine.Vector3(speed,0,0));
            }
            if (key == KeyCode.Space)
            {
                Rigidbody.AddForce(new UnityEngine.Vector3(0,jumpSpeed,0));
            }
        }
    }
}
    
    


