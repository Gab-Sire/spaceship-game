using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    LevelManager levelManager;
    Animator[] animators;
    public int life = 500;
    public bool isDead = false;
    public AudioSource audioSrc;

    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
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
        if (collider.gameObject.tag.Contains("projectile_enemy"))
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
                    //Debug.Log("component destroyed successfully");
                    isDead = true;
                    levelManager.PlayerComponentKilled();
                    Destroy(gameObject);
                }
            }
        }
    }
}
