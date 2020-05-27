﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float speed = 10f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("enemy") || collider.tag.Contains("wall"))
        {
            Destroy(gameObject);
        }
    }
}
