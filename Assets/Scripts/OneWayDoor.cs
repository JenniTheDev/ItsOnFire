// Jenni
using System.Collections;
using UnityEngine;

public class OneWayDoor : Door, ITriggerable
{
    [SerializeField] private bool doorStartPosition = true;

    private void Awake()
    {
        gameObject.SetActive(doorStartPosition);
    }

    protected override void OpenDoor()
    {
        // gameObject.SetActive(!doorStartPosition);
        gameObject.SetActive(false);
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