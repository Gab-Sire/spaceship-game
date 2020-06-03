using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager = default;
    [SerializeField]
    public int life = 500;
    [SerializeField]
    public bool isDead = false;
    [SerializeField]
    public AudioSource audioSrc;

    Animator[] animators;
    
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
        if (collider.CompareTag("projectile_enemy"))
        {
            if (audioSrc != null)
            {
                audioSrc.Play();
            }
            
            life -= 50;

            foreach (Animator animator in animators)
            {
                animator.SetBool("isHit", true);

                if (life < 0 && !isDead)
                {
                    Debug.Log("component destroyed successfully", gameObject);
                    isDead = true;
                    levelManager.PlayerComponentKilled();
                    Destroy(gameObject);
                }
            }
        }
    }
}
