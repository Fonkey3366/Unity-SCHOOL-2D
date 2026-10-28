using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public SpriteRenderer Render;

    public bool userandom;

    public bool speed;
    public bool slowed;

    private void Awake()
    {
        Render = this.gameObject.GetComponent<SpriteRenderer>();

        if (userandom)
        {
            speed = false;
            slowed = false;
            int which = Random.Range(1, 3);

            if (which == 1)
            {
                speed = true;
                Render.color = Color.green;
            }

            if (which == 2)
            {
                slowed = true;
                Render.color = Color.red;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Movement d = col.GetComponentInParent<Movement>();

        if (col.CompareTag("Player"))
        {
            if (speed)
            {
                d.Powerup("Speed");
            }

            if (slowed)
            {
                d.Powerup("Slowed");
            }

           Destroy(gameObject);
        }
        else
        {
            Debug.LogError("De Player werd geraakt, maar er is geen 'Movement' script gevonden op " + col.name);
        }

    }
}
