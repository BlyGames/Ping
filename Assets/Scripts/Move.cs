using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector2 moveSpeed;// = new Vector2(1,1);
    bool canMove;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed *= 10;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.velocity = moveSpeed *Time.fixedDeltaTime;
        //canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(rb2d.velocity.y  == 0)
        {
            if(transform.position.y > 0)
            {
                //rb2d.AddForce(new Vector2(0, -0.05f));
                rb2d.velocity = new Vector2(0,(moveSpeed.y*-1) * Time.fixedDeltaTime);
            } else
            {
                rb2d.velocity = new Vector2(0, moveSpeed.y * Time.fixedDeltaTime);
            }
        } else if (rb2d.velocity.x == 0)
        {
            if (transform.position.x > 0)
            {
                rb2d.AddForce(new Vector2(0.1f,0));
            }
            else
            {
                rb2d.AddForce(new Vector2(-0.1f,0));
            }
        }
    }
}
