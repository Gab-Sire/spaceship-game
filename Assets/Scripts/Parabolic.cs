using UnityEngine;

public class Parabolic : MonoBehaviour
{
    public float life = 200;
    public float moveSpeed = 10.0f;
    LevelManager levelManager;
    public short scoreReward = 25;
    Rigidbody2D rigidbody2D;
    Animator[] animators;
    BoxCollider[] boxColliders;
    bool isDead = false;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        animators = GetComponentsInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = -transform.right * moveSpeed;
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

                if (life < 0 && !isDead)
                {
                    Debug.Log("ship destroyed successfully");
                    LevelManager.UpdateScore(scoreReward);
                    isDead = true;
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Wall_left"))
        {
            Destroy(gameObject);
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
