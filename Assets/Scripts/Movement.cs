using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform Camera;
    public Transform Player;

    public SpriteRenderer mirthe;

    public Rigidbody2D rb;
    float horizontal;
    float vertical;

    public float speed;

    void Start()
    {

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        if (horizontal > 0)
        {
            mirthe.flipX = true;
        }
        else
        {
            mirthe.flipX = false;
        }
            Camera.position = Player.position + new Vector3(0f, 0f, -10f);

        Debug.Log("positie:" + Player.transform.position);
    }
}
