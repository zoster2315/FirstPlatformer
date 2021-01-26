using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public float JumpForce;
    private Rigidbody2D rb2d;
    private float distToGround;
    private CapsuleCollider2D collid;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collid = GetComponent<CapsuleCollider2D>();
        distToGround = collid.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        var moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(0, 1);

        if (IsGrounded() && moveVertical > 0)
            rb2d.AddForce(movement * JumpForce);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector2.up, distToGround + 0.1f);
    }
}
