using UnityEngine;

public class Parabolic : MonoBehaviour
{
    [SerializeField]
    float life = 200;
    [SerializeField]
    float moveSpeed = 10.0f;
    [SerializeField]
    short scoreReward = 25;

    LevelManager levelManager;
    new Rigidbody2D rigidbody2D;
    Animator[] animators;
    BoxCollider[] boxColliders;
    bool isDead = false;

    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = -transform.right * moveSpeed;
        levelManager = FindObjectOfType<LevelManager>();
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
        if (collider.CompareTag("projectile_player"))
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
                    Debug.Log("parabolic destroyed successfully", gameObject);
                    levelManager.UpdateScore(scoreReward);
                    isDead = true;
                    Destroy(gameObject, 0.1f);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Wall_left"))
        {
            Destroy(gameObject, 1.0f);
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
