using System.Collections;
using UnityEngine;

public class DelayDoor : Door, ITriggerable
{
    [SerializeField] private float delay = 0.75f;

    protected override void OpenDoor()
    {
        StartCoroutine(OpenAfterDelay());
    }

    private IEnumerator OpenAfterDelay()
    {
        yield return new WaitForSeconds(delay);

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