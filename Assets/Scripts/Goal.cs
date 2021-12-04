using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioSource soundPlayer;
    private LayerMask ballLayer;

    private void Start()
    {
        ballLayer = LayerMask.NameToLayer("Ball");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == ballLayer)
        {
            // Debug.Log("Play sound");
            soundPlayer.clip = winSound;
            soundPlayer.Play();
        }
    }
}