// Jenni
using System.Collections;
using UnityEngine;

public class OpenOnlyDoor : MonoBehaviour, ITriggerable
{
    [SerializeField] private bool doorStartPosition;
    private float delay = 0.5f;

    private void Awake()
    {
        gameObject.SetActive(doorStartPosition);
    }

    public void OpenDoor()
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