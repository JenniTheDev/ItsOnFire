using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Variables;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private IntVariable score;
    [SerializeField] private IntVariable playerHealth;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text playerHealthText;

    public void Awake()
    {
        // subscribe to event
    }

    private void OnScoreUpdate()
    {
        scoreText.text = score.IntValue.ToString();
    }

    private void OnPlayerHealthUpdate()
    {
        playerHealthText.text = playerHealth.IntValue.ToString();
    }
}