using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float smoothing;
    

    private Rigidbody2D rigidBody;
    private Vector3 velocity = Vector3.zero;


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

    }
}