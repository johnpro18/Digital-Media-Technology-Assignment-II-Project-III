using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    [SerializeField] private GameObject completeLevelUI;
    [SerializeField] public CoinsCounter coinsCounter;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("Completed");
            completeLevelUI.SetActive(true);
            AudioSource.PlayClipAtPoint(audio, transform.position);
        }
    }
}
