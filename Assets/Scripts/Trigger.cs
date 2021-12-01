using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    [SerializeField] private bool isTriggered;
    [SerializeField] private Collider[] canTripColliders;

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
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!this.isTriggered && CanTrip(collision))
        {
            Debug.Log("Trigger triggered and fired");
            FireTrigger();
        }
    }

    private bool CanTrip(Collider collision)
    {
        foreach (Collider col in canTripColliders)
        {
            if (col.tag == "Player") { return true; }
        }
        return false;
    }

    protected virtual void FireTrigger()
    {
        Debug.Log("Trigger Fired");
        bool hasChanged = IsTriggered == false;
        this.isTriggered = true;
    }

    public void ResetTrigger()
    {
        this.isTriggered = false;
    }
}