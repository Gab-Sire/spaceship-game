using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabolic : MonoBehaviour
{
    public float life = 200;
    Animator[] animators;
    BoxCollider[] boxColliders;

    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
    }

    void Update()
    {

        foreach (Animator animator in animators)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("hit"))
            {
                animator.SetBool("isHit", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("projectile_player"))
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("isHit", true);

                if (collider.gameObject.name.Contains("Bullet"))
                {
                    life -= 10;
                }
                else if (collider.gameObject.name.Contains("Missile"))
                {
                    life -= 100;
                }

                if (life < 0)
                {
                    Debug.Log("ship destroyed successfully");
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (MissileLauncher.target == null)
        {
            MissileLauncher.target = transform;
        }

    }
}
