using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private Vector2 positionInitial;

    public Vector2 currentGoal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        positionInitial = transform.position;
        
    }

    private void Update()
    {
        if (Mathf.Abs(((Vector2)transform.position - currentGoal). magnitude) < 0.25)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentGoal =(collision.transform.position - transform.position).normalized;
            rb.velocity = currentGoal.normalized * speed;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            currentGoal = (positionInitial - (Vector2)transform.position).normalized;
            rb.velocity = currentGoal * speed;
        }
    }
}
