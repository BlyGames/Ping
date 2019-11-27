using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    public int setMoveSpeed;
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        setMoveSpeed *= 10;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveSpeed = Input.GetAxis("Vertical") * setMoveSpeed * Time.fixedDeltaTime;
        rb2d.velocity = new Vector2(0, moveSpeed);
    }
}
