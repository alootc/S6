using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("STARS")]
    [SerializeField] private float speed;
    [SerializeField] private int score = 0;

    [Header("SHOOT")]
    [SerializeField] private Bullet bullet;

    private Rigidbody2D rb;

    private Vector2 movement;

   public int Score { get { return score; } set { score = value; } }
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Bullet b = Instantiate(bullet, transform.position, Quaternion.identity);
            b.SetDirection(mouseInput.normalized, this);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * speed;
    }
}
