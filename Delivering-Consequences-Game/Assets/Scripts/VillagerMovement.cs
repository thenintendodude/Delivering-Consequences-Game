using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    public float MoveSpeed = 2.0f;
    private Rigidbody2D VillagerRigidBody;
    public bool IsWalking;
    public bool FacePlayer;
    public Animator VillagerAnimator;

    public float WalkTime = 1.0f;
    private float WalkCounter = 0.0f;
    public float WaitTime = 3.0f;
    private float WaitCounter = 0.0f;

    private int WalkDirection;

    // Start is called before the first frame update
    void Start()
    {
        FacePlayer = false;
        VillagerRigidBody = GetComponent<Rigidbody2D>();
        WaitCounter = WaitTime;
        WalkCounter = WalkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (FacePlayer)
        {
            UpdateToFacePlayer();
        }
        else if (IsWalking)
        {
            WalkCounter -= Time.deltaTime;

            switch(WalkDirection)
            {
                case 0:
                    VillagerRigidBody.velocity = new Vector2(0, MoveSpeed);
                    break;
                
                case 1:
                    VillagerRigidBody.velocity = new Vector2(MoveSpeed, 0);
                    break;

                case 2:
                    VillagerRigidBody.velocity = new Vector2(0, -MoveSpeed);
                    break;

                case 3:
                    VillagerRigidBody.velocity = new Vector2(-MoveSpeed, 0);
                    break;
            }

            if (WalkCounter < 0)
            {
                IsWalking = false;
                WaitCounter = WaitTime;
            }

            VillagerAnimator.SetFloat("Horizontal", VillagerRigidBody.velocity.x);
            VillagerAnimator.SetFloat("Vertical", VillagerRigidBody.velocity.y);
            VillagerAnimator.SetFloat("Speed", VillagerRigidBody.velocity.sqrMagnitude);
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

    private void UpdateToFacePlayer()
    {
        var PlayerPosition = Player.transform.position;
        var NPCPosition = this.transform.position;
        //Debug.Log("Player:" + PlayerPosition + "NPC: " + NPCPosition);

        if (PlayerPosition.x < NPCPosition.x && (
            (PlayerPosition.y > NPCPosition.y && PlayerPosition.y < (NPCPosition.y + .35))
            || (PlayerPosition.y < NPCPosition.y && PlayerPosition.y > (NPCPosition.y - .1))))
        {
            Debug.Log("Face West");
        }
        else if (PlayerPosition.x > NPCPosition.x && (
                (PlayerPosition.y  > NPCPosition.y && PlayerPosition.y < (NPCPosition.y + .35))
                || (PlayerPosition.y < NPCPosition.y && PlayerPosition.y > (NPCPosition.y - .1))))
        {
            Debug.Log("Face East");
        }
        else if (PlayerPosition.y > NPCPosition.y)
        {
            Debug.Log("Face North");
        }
        else
        {
            Debug.Log("Face South");
        }
    }
}
