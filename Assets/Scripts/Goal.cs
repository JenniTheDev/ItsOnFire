using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

[RequireComponent(typeof(IntVariable))]
public class Goal : MonoBehaviour
{
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioSource soundPlayer;
    [SerializeField] private IntVariable score;
    [SerializeField] private IntVariable goalPoints;
    private LayerMask ballLayer;

    private void Start()
    {
        ballLayer = LayerMask.NameToLayer("Ball");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == ballLayer)
        {
            score.IntValue = score.IntValue + goalPoints.IntValue;
            soundPlayer.clip = winSound;
            soundPlayer.Play();
        }
    }
}