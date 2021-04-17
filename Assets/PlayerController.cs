using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float smoothing;
    public int ticksBetweenAnimation = 5;
    public enum AnimationDirection
    {
        Up,
        Down,
        Left,
        Right,
        Idle
    }
    public Sprite[] spriteup;
    public Sprite[] spritedown;
    public Sprite[] spriteleft;
    public Sprite[] spriteright;
    public SpriteRenderer spriterenderer;

    private Rigidbody2D rigidBody;
    private Vector3 velocity = Vector3.zero;
    private AnimationDirection animationDirection = AnimationDirection.Down;
    private int animationIndex = 0;
    private int framecounter = 0;



    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var targetX = Input.GetAxisRaw("Horizontal");
        var targetY = Input.GetAxisRaw("Vertical");
        Vector3 targetVelocity = new Vector2(targetX, targetY);
        targetVelocity.Normalize();
        targetVelocity *= movementSpeed;
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, smoothing);
    
        if(Input.GetKeyDown(KeyCode.N))
        {
            DayNightManager.ChangeTime();
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(DayNightManager.Time);
        }
    }

    private void FixedUpdate()
    {
        CheckDirection();
        if (animationDirection == AnimationDirection.Up)
        {
            if (ticksBetweenAnimation <= framecounter)
            {
                framecounter = 0;
                animationIndex++;
                if (animationIndex >= spriteup.Length)
                {
                    animationIndex = 0;
                }
            }
            else
            {
                framecounter++;
            }
            spriterenderer.sprite = spriteup[animationIndex];
        }
        else if (animationDirection == AnimationDirection.Down)
        {
            if (ticksBetweenAnimation <= framecounter)
            {
                framecounter = 0;
                animationIndex++;
                if (animationIndex >= spritedown.Length)
                {
                    animationIndex = 0;
                }
            }
            else
            {
                framecounter++;
            }
            spriterenderer.sprite = spritedown[animationIndex];
        }
        else if (animationDirection == AnimationDirection.Left)
        {
            if (ticksBetweenAnimation <= framecounter)
            {
                framecounter = 0;
                animationIndex++;
                if (animationIndex >= spriteup.Length)
                {
                    animationIndex = 0;
                }
            }
            else
            {
                framecounter++;
            }
            spriterenderer.sprite = spriteleft[animationIndex];
        }
        else if (animationDirection == AnimationDirection.Right)
        {
            if (ticksBetweenAnimation <= framecounter)
            {
                framecounter = 0;
                animationIndex++;
                if (animationIndex >= spriteright.Length)
                {
                    animationIndex = 0;
                }
            }
            else
            {
                framecounter++;
            }
            spriterenderer.sprite = spriteright[animationIndex];
        }
    }
    void CheckDirection()
    {
        if (Mathf.Abs(rigidBody.velocity.x) > Mathf.Abs(rigidBody.velocity.y))
        {
            if (Mathf.Abs(rigidBody.velocity.x) < 0.01f)
            {
                animationDirection = AnimationDirection.Idle;
            }
            else if (rigidBody.velocity.x > 0.0f)
            {
                animationDirection = AnimationDirection.Right;
            }
            else
            {
                animationDirection = AnimationDirection.Left;
            }
        }
        else if (Mathf.Abs(rigidBody.velocity.y) > Mathf.Abs(rigidBody.velocity.x))
        {
            if (Mathf.Abs(rigidBody.velocity.y) < 0.01f)
            {
                animationDirection = AnimationDirection.Idle;
            }
            else if (rigidBody.velocity.y > 0.0f)
            {
                animationDirection = AnimationDirection.Up;
            }
            else
            {
                animationDirection = AnimationDirection.Down;
            }
        }
    }
}