﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector3 initialVelocity;

    [SerializeField]
    private float speed = 8;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;

    private GameObject paddle;

    private bool hasStarted = false;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        paddle = GameObject.Find("Paddle");
    }

    private void Update()
    {
        if (!hasStarted && Input.anyKeyDown)
        {
            rb.velocity = new Vector3(Random.Range(-4, 4), 1, 0).normalized * speed;
            hasStarted = true;
        }

        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Paddle")
        {
            if (!LeanTween.isTweening(this.gameObject))
            {
                LeanTween.scale(this.gameObject, transform.localScale * 1.5f, 0.1f).setLoopPingPong(1);
            }
            Bounce(collision.contacts[0].normal);
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            speed += 0.4f;
            HitPaddle(collision);
        }
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        rb.velocity = direction * speed;
    }

    /**
    Action when paddle is hit by the ball.
    The ball is reflected by the paddle, dependent on the hit position.
    When the ball hits the center of the paddle, the ball goes straight up.
    The more the ball hits the side, the more it gets reflected to this side. 
    */
    private void HitPaddle(Collision collision)
    {
        Vector3 paddlePosition = paddle.transform.position;
        Vector3 hitPosition = collision.GetContact(0).point;
        float paddleWidth = 4f;

        // relative paddle hit position between -1 & +1
        float normalizedHitPositionX = (paddlePosition.x - hitPosition.x) / (paddleWidth / 2);
        float maxBounceAngle = 70f;
        Vector3 direction = Quaternion.AngleAxis(normalizedHitPositionX * maxBounceAngle, Vector3.forward) * Vector3.up;
        rb.velocity = direction * speed;
    }
}
