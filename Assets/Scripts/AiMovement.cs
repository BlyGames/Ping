using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public Transform ball;
    Rigidbody2D rb2d;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(ball.position.x > 0)
        {
            if(ball.position.y > transform.position.y)
            {
                rb2d.velocity = new Vector2(0, moveSpeed);
                //Debug.Log("AI moving up");
            } else if(ball.position.y < transform.position.y)
            {

                rb2d.velocity = new Vector2(0, (moveSpeed * -1));
                //Debug.Log("AI moving down");
            }
        }
    }
}
