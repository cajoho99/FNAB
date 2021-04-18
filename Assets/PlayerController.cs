using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float smoothing;
    public enum AnimationDirection
    {
        Up,
        Down,
        Left,
        Right,
        Idle
    }
    public SpriteAnimation animUp;
    public SpriteAnimation animRight;
    public SpriteAnimation animDown;
    public SpriteAnimation animLeft;

    private Rigidbody2D rigidBody;
    private Vector3 velocity = Vector3.zero;
    private AnimationDirection animationDirection = AnimationDirection.Idle;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animDown.SetDefault();
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

        if (Input.GetKeyDown(KeyCode.N))
        {
            DayNightManager.ChangeTime();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(DayNightManager.Time);
        }
    }

    private void FixedUpdate()
    {
        var prevAnimDir = animationDirection;
        var changed = CheckDirection();
        if (changed)
        {
            var prevAnim = GetAnim(prevAnimDir);
            if (prevAnim)
            {
                prevAnim.Disable();
            }
            switch (animationDirection)
            {
                case AnimationDirection.Up:
                    animUp.Enable();
                    break;
                case AnimationDirection.Right:
                    animRight.Enable();
                    break;
                case AnimationDirection.Down:
                    animDown.Enable();
                    break;
                case AnimationDirection.Left:
                    animLeft.Enable();
                    break;
                case AnimationDirection.Idle:
                    prevAnim.SetDefault();
                    break;
            }
        }
    }
    private bool CheckDirection()
    {
        AnimationDirection newDirection = AnimationDirection.Idle;
        if (Mathf.Abs(rigidBody.velocity.x) > Mathf.Abs(rigidBody.velocity.y))
        {
            if (Mathf.Abs(rigidBody.velocity.x) < 0.01f)
            {
                newDirection = AnimationDirection.Idle;
            }
            else if (rigidBody.velocity.x > 0.0f)
            {
                newDirection = AnimationDirection.Right;
            }
            else
            {
                newDirection = AnimationDirection.Left;
            }
        }
        else if (Mathf.Abs(rigidBody.velocity.y) > Mathf.Abs(rigidBody.velocity.x))
        {
            if (Mathf.Abs(rigidBody.velocity.y) < 0.01f)
            {
                newDirection = AnimationDirection.Idle;
            }
            else if (rigidBody.velocity.y > 0.0f)
            {
                newDirection = AnimationDirection.Up;
            }
            else
            {
                newDirection = AnimationDirection.Down;
            }
        }

        if (newDirection != animationDirection)
        {
            animationDirection = newDirection;
            return true;
        }
        else
        {
            animationDirection = newDirection;
            return false;
        }
    }

    private SpriteAnimation GetAnim(AnimationDirection dir)
    {
        switch (dir)
        {
            case AnimationDirection.Up:
                return animUp;
            case AnimationDirection.Right:
                return animRight;
            case AnimationDirection.Down:
                return animDown;
            case AnimationDirection.Left:
                return animLeft;
            default:
                return null;
        }
    }
}