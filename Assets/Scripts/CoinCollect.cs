using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int coins;

    public string Tag;

    public AudioSource Collectsound;

    public TextMeshProUGUI teller;

    public GameObject pickupeffect;
    public GameObject Powerupeffect;

    private Vector3 pos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            pos = other.transform.position;

            if (pickupeffect != null)
            {
                StartCoroutine(Killeffect(2f, "Coin")); // Verandert naar een float voor seconden
            }

            Updatetext();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Powerup"))
        {
            pos = other.transform.position;

            if (pickupeffect != null)
            {
                StartCoroutine(Killeffect(2f, "Powerup")); // Verandert naar een float voor seconden
            }
        }
    }

    private void Updatetext()
    {
        coins++;
        Collectsound.Play();
        teller.text = "Coins collected: " + coins;
    }

    IEnumerator Killeffect(float time, String name)
    {
        if (name == "Coin")
        {
            GameObject Killthis = Instantiate(pickupeffect, pos, Quaternion.identity);
            yield return new WaitForSeconds(time);
            Destroy(Killthis);
        }

        if (name == "Powerup")
        {
            GameObject Killthis = Instantiate(Powerupeffect, pos, Quaternion.identity);
            yield return new WaitForSeconds(time);
            Destroy(Killthis);
        }
    }
}
