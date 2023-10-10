using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Bullet bullet;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            Bullet b = Instantiate(bullet, transform.position, Quaternion.identity);
            b.SetDirection(transform.right);

            yield return new WaitForSeconds(5);
        }
        
    }
}
