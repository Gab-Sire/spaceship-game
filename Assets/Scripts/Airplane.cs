using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float life = 100;
    public float moveSpeed = 3.0f;
    public float delayNextShooting = 0.5f;
    public Transform firePoint;
    public GameObject laserProjectilePrefab;
    public bool isAbleToShoot = true;
    public short scoreReward = 50;

    GameObject player;
    LevelManager levelManager;
    PlayerComponent[] playerComponents;
    BoxCollider2D[] playerBoxColliders;
    Animator animator;
    float nextFireTime = 0.0f;
    bool isDead = false;
    bool hasSpawned = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        levelManager = FindObjectOfType<LevelManager>();
        playerComponents = player.GetComponentsInChildren<PlayerComponent>();
        playerBoxColliders = player.GetComponentsInChildren<BoxCollider2D>();

        // TODO calculatePlayerPosAndMove();
    }

    void Update()
    {
        if (hasSpawned && transform.position.x > 22)
        {
            transform.position -= new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
        else if (hasSpawned && transform.position.x <= 22)
        {
            hasSpawned = false;
        }

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

            if (life < 0 && !isDead)
            {
                Debug.Log("ship destroyed successfully");
                isDead = true;
                levelManager.UpdateRemainingEnemiesFromWave(1);
                LevelManager.UpdateScore(scoreReward);
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

    private void calculatePlayerPosAndMove()
    {
        for (int i = 0; i < 3; i++)
        {
            
        }
    }
}
