using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float startForce = 20.0f;
    private float spawnDirectionMin = -10.0f;
    private float spawnDirectionMax = 10.0f;
    private Rigidbody rb;
    private LayerMask goalLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        goalLayer = LayerMask.NameToLayer("Goal");
        PickRandomColor();
        LaunchBall();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == goalLayer)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void LaunchBall()
    {
        rb.AddForce(Random.Range(spawnDirectionMin, spawnDirectionMax), 0, Random.Range(spawnDirectionMin, spawnDirectionMax) * startForce);
    }

    private void PickRandomColor()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}