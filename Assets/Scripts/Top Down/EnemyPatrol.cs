using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] checkpointsPatrol;
    [SerializeField] private Rigidbody2D myRBD2;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speedMin = 3f;
    [SerializeField] private float speedMax = 5f;

    [SerializeField] private float distance;

    private Transform currentPositionTarget;
    private int patrolPos = 0;

    private float speedCurrent;

    private void Start()
    {
        currentPositionTarget = checkpointsPatrol[patrolPos];
        transform.position = currentPositionTarget.position;

        speedCurrent = speedMin;
    }

    private void Update()
    {
        CheckPlayer();
        CheckNewPoint();
       // transform.movet
    }

    private void CheckNewPoint()
    {
        if (Mathf.Abs((transform.position - currentPositionTarget.position).magnitude) < 0.25)
        {
            patrolPos = patrolPos + 1 == checkpointsPatrol.Length ? 0 : patrolPos + 1;
            currentPositionTarget = checkpointsPatrol[patrolPos];
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized * speedCurrent;

            CheckFlip(myRBD2.velocity.x);
        }

    }

    private void CheckPlayer()
    {
        Vector2 direction = currentPositionTarget.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);

        if(hit.collider == null)
        {
            speedCurrent = speedMax;
        }
        else
        {
            speedCurrent = speedMin;
        }
    }

    private void CheckFlip(float x_Position)
    {
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
}
