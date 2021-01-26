using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriterender;
    private bool isGrounded = true;
    public float speed = 0.3f;
    public float maxSpeed = 20f;
    public float jumpSpeed = 25f;

    [SerializeField]
    Transform GroundCheck;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        Move();
    }

    private void Move()
    {
        var velocity = rb2d.velocity;
        rb2d.velocity = GetVelocity();
    }

    private Vector2 GetVelocity()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var velocity = new Vector2(GetxVelocity(moveHorizontal), GetyVelocity(moveVertical));
        return velocity;
    }

    private float GetxVelocity(float moveHorizontal)
    {
        var velocity = rb2d.velocity;
        var xVelocity = velocity.x;
        if (moveHorizontal > 0)
        {
            if (xVelocity <= maxSpeed)
                xVelocity += speed;
            if (xVelocity > maxSpeed)
                xVelocity = maxSpeed;
            spriterender.flipX = false;
        }
        else if (moveHorizontal < 0)
        {
            if (xVelocity >= -maxSpeed)
                xVelocity -= speed;
            if (xVelocity < -maxSpeed)
                xVelocity = -maxSpeed;
            spriterender.flipX = true;
        }
        return xVelocity;
    }

    private float GetyVelocity(float moveVertical)
    {
        var velocity = rb2d.velocity;
        var yVelocity = velocity.y;
        if (isGrounded && moveVertical > 0)
            yVelocity = jumpSpeed;
        return yVelocity;
    }

    private void IsGrounded()
    {
        isGrounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Foreground"));
        if (isGrounded)
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
    }

}
