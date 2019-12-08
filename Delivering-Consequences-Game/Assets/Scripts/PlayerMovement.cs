﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private Rigidbody2D CharRigidBody;
    [SerializeField] private Animator CharAnimator;
    Vector2 Movement;

    // Update is called once per frame
    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        CharAnimator.SetFloat("Horizontal", Movement.x);
        CharAnimator.SetFloat("Vertical", Movement.y);
        CharAnimator.SetFloat("Speed", Movement.sqrMagnitude);
        CharAnimator.speed = pressingRun() ? 1.5f : 1f;
    }

    void FixedUpdate() 
    {
        var currentMoveSpeed = MoveSpeed;
        if (pressingRun())
        {
            currentMoveSpeed = 1.5f * MoveSpeed;
        }
        CharRigidBody.MovePosition(CharRigidBody.position + Movement * currentMoveSpeed * Time.fixedDeltaTime);
    }

    bool pressingRun()
    {
        return Input.GetMouseButton(1); // Right Click
    }
}
