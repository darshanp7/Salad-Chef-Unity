using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    internal bool canMove;
    private float vertical;
    private float horizontal;
    private Player player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw(player.hAxis);
        vertical = Input.GetAxisRaw(player.yAxis);
        if (!canMove) return;
        var movement = new Vector2(horizontal, vertical);
        rb.velocity = Time.deltaTime * speed * movement;
    }
}
