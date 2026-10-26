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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Updatetext();
            Destroy(other.gameObject);
        }
    }

    private void Updatetext()
    {
        coins++;
        Collectsound.Play();
        teller.text = "Coins collected: " + coins;
    }
}
