using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] private int currentHealthPoints;
    public IntVariable MaxHealthPoints;

    private void Awake()
    {
        currentHealthPoints = MaxHealthPoints.IntValue;
    }

    private void Update()
    {
    }
}