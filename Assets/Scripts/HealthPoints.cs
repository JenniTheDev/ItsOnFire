using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] private int currentHealthPoints;
    [SerializeField] private IntVariable maxHealthPoints;

    private void Awake()
    {
        currentHealthPoints = maxHealthPoints.IntValue;
    }

    private void Update()
    {
    }
}