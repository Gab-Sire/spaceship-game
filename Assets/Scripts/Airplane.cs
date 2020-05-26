using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float life = 100;
    public float delayNextShooting = 0.5f;
    public Transform firePoint;
    public GameObject laserProjectilePrefab;
    public bool isAbleToShoot = true;

    Animator animator;
    float nextFireTime = 0.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("hit"))
        {
            animator.SetBool("isHit", false);
        }

        if (isAbleToShoot)
        {
            if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + delayNextShooting;
                Shoot();
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("projectile_player"))
        {
            animator.SetBool("isHit", true);

            if (collider.gameObject.name.Contains("Bullet"))
            {
                life -= 10;
                Debug.Log("ship attacked, -10 life");
            }
            else if (collider.gameObject.name.Contains("Missile"))
            {
                life -= 100;
                Debug.Log("ship attacked, -100 life");
            }

            if (life < 0)
            {
                Debug.Log("ship destroyed successfully");
                Destroy(gameObject);
            }
        }
    }

    void Shoot()
    {
        Instantiate(laserProjectilePrefab, firePoint.transform.position, transform.rotation);
    }

    private void OnMouseDown()
    {
        if (MissileLauncher.target == null)
        {
            MissileLauncher.target = transform;
        }
        
    }
}
