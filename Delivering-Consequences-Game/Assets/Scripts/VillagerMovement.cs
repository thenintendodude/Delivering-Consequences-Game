using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float MoveSpeed = 2.0f;
    [SerializeField] private bool IsWalking;
    [SerializeField] private Animator VillagerAnimator;
    private Rigidbody2D VillagerRigidBody;
    private bool FacePlayer;

    // Random movement vars.
    [SerializeField] private float WalkTime = 1.0f;
    [SerializeField] private float WaitTime = 3.0f;
    private float WalkCounter = 0.0f;
    private float WaitCounter = 0.0f;
    private int WalkDirection;

    // Face Player constants.
    private float UpperThreshold = .35f;
    private float LowerThreshold = .2f;

    // Villager direction sprites.
    [SerializeField] private Sprite LeftSprite;
    [SerializeField] private Sprite RightSprite;
    [SerializeField] private Sprite UpSprite;
    [SerializeField] private Sprite DownSprite;
    private SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        FacePlayer = false;
        SpriteRenderer = GetComponent<SpriteRenderer>();

        VillagerRigidBody = GetComponent<Rigidbody2D>();
        WaitCounter = WaitTime;
        WalkCounter = WalkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        VillagerAnimator.enabled = true;
        SpriteRenderer.sprite = DownSprite;

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

    public void setFacePlayer(bool CurrentStatus)
    {
        this.FacePlayer = CurrentStatus;
    }

    private bool PlayerBesideNPC(Vector3 PlayerPosition, Vector3 NPCPosition)
    {
        return (PlayerPosition.y > NPCPosition.y && PlayerPosition.y < (NPCPosition.y + UpperThreshold))
            || (PlayerPosition.y < NPCPosition.y && PlayerPosition.y > (NPCPosition.y - LowerThreshold));
    }

    private void UpdateToFacePlayer()
    {
        var PlayerPosition = Player.transform.position;
        var NPCPosition = this.transform.position;

        // NPC Stops Walking.
        VillagerAnimator.enabled = false;
        IsWalking = false;
        VillagerRigidBody.velocity = Vector2.zero;
        VillagerAnimator.SetFloat("Speed", VillagerRigidBody.velocity.sqrMagnitude);

        // Find Player position relative to NPC,
        if (PlayerPosition.x < NPCPosition.x && PlayerBesideNPC(PlayerPosition, NPCPosition))
        {
            SpriteRenderer.sprite = LeftSprite;
        }
        else if (PlayerPosition.x > NPCPosition.x && PlayerBesideNPC(PlayerPosition, NPCPosition))
        {
            SpriteRenderer.sprite = RightSprite;
        }
        else if (PlayerPosition.y > NPCPosition.y)
        {
            SpriteRenderer.sprite = UpSprite;
        }
        else
        {
            SpriteRenderer.sprite = DownSprite;
        }
    }
}
