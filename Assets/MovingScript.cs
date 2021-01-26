using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        var velocity = rb2d.velocity;
        var moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(0, 0);
        if (moveHorizontal > 0)
        {
            movement.x = 1;
            if (velocity.x < 0)
                movement.x = 2;
        }
        else if (moveHorizontal < 0)
        {
            movement.x = -1;
            if (velocity.x > 0)
                movement.x = -2;
        }

        if (velocity.x < maxSpeed && velocity.x > -maxSpeed)
            rb2d.AddForce(movement * speed);

        if (moveHorizontal == 0f)
        {
            if (velocity.x > 0)
                movement.x = -1;
            else
                movement.x = 1;
            rb2d.AddForce(movement * speed);
        }
    }
}
