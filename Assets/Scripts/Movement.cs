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

    [Header("powerups")]
    public float speedboost;
    public bool Effectcooldown;

    void Start()
    {

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * 0);

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

    public void Powerup(string type)    
    {
        if (type == "Speed")
        {
            speed = speedboost;
            StartCoroutine(SpeedReset(2));
        }

        if (type == "Slowed")
        {
            speed = 3f;
            StartCoroutine(SpeedReset(3));
        }
    }

    IEnumerator SpeedReset(int seconds)
    {
        if (!Effectcooldown)
        {
            yield return new WaitForSeconds(seconds);
            speed = 5f;
        }
        else
        {
            Debug.Log("Cooldown: " + Effectcooldown);
        }
    }
}
