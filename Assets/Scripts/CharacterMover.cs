using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public UserInput userInput;
    private Rigidbody2D rb2d;

    public float characterSpeed;

    private Vector2 goalDirection;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        goalDirection = userInput.GetDirectionalInput().normalized;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = goalDirection * characterSpeed;
    }
}
