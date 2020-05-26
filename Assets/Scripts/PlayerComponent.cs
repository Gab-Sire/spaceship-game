using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    Animator[] animators;
    public int life = 500;

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
        if (collider.gameObject.tag.Contains("projectile_enemy"))
        {
            life -= 50;

            foreach (Animator animator in animators)
            {
                animator.SetBool("isHit", true);

                if (life < 0)
                {
                    Debug.Log("component destroyed successfully");
                    Destroy(gameObject);
                }
            }
        }
    }
}
