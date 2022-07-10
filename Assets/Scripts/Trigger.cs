using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour, ITriggerable
{
    [SerializeField] private bool isTriggered;
    [SerializeField] private Collider[] canTripColliders;
    private LayerMask playerLayer;
    [SerializeField] private GameObject doorToClose;

    public bool IsTriggered
    {
        get { return this.isTriggered; }
    }

    private void Start()
    {
        if (this.canTripColliders == null || this.canTripColliders.Length < 1)
        {
            Debug.Log($"FYI: Trigger {gameObject.name} has no colliders set");
        }
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!this.isTriggered && CanTrip(collision))
        {
            Debug.Log($"Trigger Fired by {collision.gameObject.name}.");
            TriggerExecute();
        }
    }

    private bool CanTrip(Collider collision)
    {
        foreach (Collider col in canTripColliders)
        {
            if (col.gameObject.layer == playerLayer) { return true; }
        }
        return false;
    }

    public void TriggerExecute()
    {
        Debug.Log("Trigger Executed");
        this.isTriggered = true;
        doorToClose.SetActive(false);
    }

    public void TriggerRelease()
    {
        ResetTrigger();
    }

    public void ResetTrigger()
    {
        this.isTriggered = false;
    }
}