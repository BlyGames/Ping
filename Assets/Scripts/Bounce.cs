using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d, prb2d;
    public float impactSpeed,reductionAmmount;
    public Vector2 vel, startVel;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startVel == new Vector2(0,0)) startVel = rb2d.velocity;
        vel = rb2d.velocity;
        //Debug.Log(vel);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        rb2d.velocity = Vector3.Reflect(vel, col.contacts[0].normal);
        //vel = rb2d.velocity;
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "AI")
        {
            if (prb2d == null)
            {
                prb2d = col.gameObject.GetComponent<Rigidbody2D>();
                AddVelocity(prb2d);
            } else
            {
                AddVelocity(prb2d);
            }
        } else
        {
            ReduceVelocity();
        }
        //rb2d.velocity = Vector3.Reflect(vel, col.contacts[0].normal);
    }
    void ReduceVelocity()
    {
        if(rb2d.velocity.x > startVel.x)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x - reductionAmmount, rb2d.velocity.y);
        } 
        if(rb2d.velocity.y > startVel.y)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y - (2*reductionAmmount));
        }
        if (rb2d.velocity.x < (startVel.x*-1))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x + reductionAmmount, rb2d.velocity.y);
        }
        if (rb2d.velocity.y < (startVel.y*-1))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + (2*reductionAmmount));
        }
    }
    public void AddVelocity(Rigidbody2D r)
    {
        if (rb2d.velocity.y > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + (Mathf.Abs(r.velocity.y) * impactSpeed));
        }
        else
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + ((Mathf.Abs(r.velocity.y)*-1) * impactSpeed));
        }
        if (rb2d.velocity.x > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x + (Mathf.Abs(r.velocity.y) * impactSpeed), rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x + ((Mathf.Abs(r.velocity.y)*-1) * impactSpeed), rb2d.velocity.y);
        }
    }
}
