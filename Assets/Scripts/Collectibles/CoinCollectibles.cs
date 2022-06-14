using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinCollectibles : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    [SerializeField] private AudioClip audio;

    public CoinsCounter coinsCounter;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            coinsCounter.SetCoinsCounter(coinValue);
            AudioSource.PlayClipAtPoint(audio, transform.position);
            gameObject.SetActive(false);
        }
    }
}
