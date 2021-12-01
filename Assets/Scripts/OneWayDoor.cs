// Jenni
using System.Collections;
using UnityEngine;

public class OneWayDoor : Door, ITriggerable
{
    [SerializeField] private bool doorStartPosition;

    private void Awake()
    {
        gameObject.SetActive(doorStartPosition);
    }

    protected override void OpenDoor()
    {
        gameObject.SetActive(!doorStartPosition);
    }

    public void TriggerExecute()
    {
        Debug.Log(" Trigger execute called");
        OpenDoor();
    }

    public void TriggerRelease()
    {
    }
}