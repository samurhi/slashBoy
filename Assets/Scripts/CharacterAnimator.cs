using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (rb2d.velocity.x >= 0.0f) transform.localScale = new Vector3(1, 1, 1);
        else transform.localScale = new Vector3(-1, 1, 1);
        animator.SetFloat("speedX", Mathf.Abs(rb2d.velocity.x));
        animator.SetFloat("velocityY", rb2d.velocity.y);
        if (rb2d.velocity.magnitude > 0.1f) animator.SetBool("isMoving", true);
        else animator.SetBool("isMoving", false);
        animator.SetFloat("maxVelocity", rb2d.velocity.magnitude);
    }
}
