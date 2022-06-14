using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip audio;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("Completed");
        }
    }
}
