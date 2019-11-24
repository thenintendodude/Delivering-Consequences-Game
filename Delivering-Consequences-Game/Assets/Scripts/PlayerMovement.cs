using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Rigidbody2D CharRigidBody;
    Vector2 Movement;
    public Animator CharAnimator;

    // Update is called once per frame
    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        
        CharAnimator.SetFloat("Horizontal", Movement.x);
        CharAnimator.SetFloat("Vertical", Movement.y);
        CharAnimator.SetFloat("Speed", Movement.sqrMagnitude);
    }

    void FixedUpdate() 
    {
        CharRigidBody.MovePosition(CharRigidBody.position + Movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
