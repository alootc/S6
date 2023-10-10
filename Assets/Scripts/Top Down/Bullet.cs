using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Player player;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    public void SetDirection(Vector2 dir, Player player)
    {
        rb.velocity = dir * speed;
        this.player = player;
    }

    public void SetDirection(Vector2 dir)
    {
        rb.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            player.Score += 10;
            MyCanvas.Instance.UpdateScore(player.Score);

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
