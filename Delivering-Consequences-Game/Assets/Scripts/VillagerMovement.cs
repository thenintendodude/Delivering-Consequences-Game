using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float MoveSpeed = 2.0f;
    private Rigidbody2D VillagerRigidBody;
    public bool IsWalking;
    public Animator VillagerAnimator;
    // Vector2 Movement;

    public float WalkTime = 1.0f;
    private float WalkCounter = 0.0f;
    public float WaitTime = 3.0f;
    private float WaitCounter = 0.0f;

    private int WalkDirection;

    // Start is called before the first frame update
    void Start()
    {
        VillagerRigidBody = GetComponent<Rigidbody2D>();
        WaitCounter = WaitTime;
        WalkCounter = WalkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsWalking)
        {
            WalkCounter -= Time.deltaTime;
            // Movement.x = Input.GetAxisRaw("Horizontal");
            // VillagerRigidBody.velocity.y = Input.GetAxisRaw("Vertical");
            
            VillagerAnimator.SetFloat("Horizontal", VillagerRigidBody.velocity.x);
            VillagerAnimator.SetFloat("Vertical", VillagerRigidBody.velocity.y);
            VillagerAnimator.SetFloat("Speed", VillagerRigidBody.velocity.sqrMagnitude);

            switch(WalkDirection)
            {
                case 0:
                    VillagerRigidBody.velocity = new Vector2(0, MoveSpeed);
                    // VillagerAnimator.SetFloat("Vertical", VillagerRigidBody.velocity.y);
                    break;
                
                case 1:
                    VillagerRigidBody.velocity = new Vector2(MoveSpeed, 0);
                    VillagerAnimator.SetFloat("Horizontal", VillagerRigidBody.velocity.x);
                    break;

                case 2:
                    VillagerRigidBody.velocity = new Vector2(0, -MoveSpeed);
                    VillagerAnimator.SetFloat("Vertical", VillagerRigidBody.velocity.y);
                    break;

                case 3:
                    VillagerRigidBody.velocity = new Vector2(-MoveSpeed, 0);
                    VillagerAnimator.SetFloat("Horizontal", VillagerRigidBody.velocity.x);
                    break;
            }

            if (WalkCounter < 0)
            {
                IsWalking = false;
                WaitCounter = WaitTime;
                // VillagerRigidBody.velocity = new Vector2(0, 0);
                // VillagerRigidBody.velocity = Vector2.zero;
            }
        }

        else
        {
            WaitCounter -= Time.deltaTime;
            VillagerRigidBody.velocity = Vector2.zero;
            VillagerAnimator.SetFloat("Speed", VillagerRigidBody.velocity.sqrMagnitude);

            if (WaitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0,4);
        IsWalking = true;
        WalkCounter = WalkTime;
    }
}
