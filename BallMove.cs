using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    
    public float speed = 5f;
    public Rigidbody2D rd;
    public Vector2 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        //moveVector.y = Input.GetAxis("Vertical");
        rd.velocity = new Vector2(moveVector.x * speed, rd.velocity.y);
        //rd.AddForce(moveVector * speed);
        //
        Jump();
        CheckingGround();
    }
    public float jumpForce = 7f;


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rd.velocity = new Vector2(rd.velocity.x, jumpForce);
        }
    }
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}