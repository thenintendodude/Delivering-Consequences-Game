using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    public float MoveSpeed = 2.0f;
    private Rigidbody2D VillagerRigidBody;
    public bool IsWalking;
    private bool FacePlayer;
    public Animator VillagerAnimator;

    // Random movement vars.
    public float WalkTime = 1.0f;
    private float WalkCounter = 0.0f;
    public float WaitTime = 3.0f;
    private float WaitCounter = 0.0f;
    private int WalkDirection;

    // Face Player constants.
    private float UpperThreshold = .35f;
    private float LowerThreshold = .2f;

    public Sprite LeftSprite;
    public Sprite RightSprite;
    public Sprite UpSprite;
    public Sprite DownSprite;
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
