using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float life = 100;
    Animator animator;

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
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("projectile"))
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

            //animator.SetBool("isHit", false);

            if (life < 0)
            {
                Debug.Log("ship destroyed successfully");
                Destroy(gameObject);
            }
        }
    }
}
