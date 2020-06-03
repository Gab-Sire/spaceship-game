using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField]
    float life = 100;
    [SerializeField]
    float moveSpeed = 3.0f;
    [SerializeField]
    float delayNextShooting = 0.5f;
    [SerializeField]
    Transform firePoint = default;
    [SerializeField]
    GameObject laserProjectilePrefab = default;
    [SerializeField]
    bool isAbleToShoot = true;
    [SerializeField]
    short scoreReward = 50;
    [SerializeField]
    AudioSource audioSrc = default;

    GameObject player;
    LevelManager levelManager;
    PlayerComponent[] playerComponents;
    BoxCollider2D[] playerBoxColliders;
    Animator animator;
    Vector2 screenBounds;

    float nextFireTime = 0.0f;
    float nextMoveTime = 0.0f;
    float height;
    bool isDead = false;
    bool hasSpawned = true;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        levelManager = FindObjectOfType<LevelManager>();
        playerComponents = player.GetComponentsInChildren<PlayerComponent>();
        playerBoxColliders = player.GetComponentsInChildren<BoxCollider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height - 20, 0));
        height = transform.GetComponent<SpriteRenderer>().bounds.size.y;
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

        if (isAbleToShoot && !hasSpawned)
        {
            if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + delayNextShooting;
                Shoot();
            }
        }
    }

    void FixedUpdate()
    {

        if (Time.time > nextMoveTime)
        {
            nextMoveTime = Time.time + 1f;
            int moveResult = Random.Range(0, 2);

            if (moveResult == 0 && (transform.position.y + height / 2) < screenBounds.y)
            {
                transform.position += new Vector3(0, 1, 0);
            }
            else if (moveResult == 1 && (transform.position.y - height / 2) > -screenBounds.y)
            {
                transform.position += new Vector3(0, -1, 0);
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
            }
            else if (collider.gameObject.name.Contains("Missile"))
            {
                life -= 100;
            }

            Debug.Log("ship attacked", gameObject);

            if (life < 0 && !isDead)
            {
                Debug.Log("ship destroyed successfully", gameObject);
                isDead = true;
                levelManager.UpdateRemainingEnemiesFromWave(1);
                levelManager.UpdateScore(scoreReward);
                Destroy(gameObject, 0.1f);
            }
        }
    }

    void Shoot()
    {
        if (audioSrc != null && !levelManager.IsGameOver())
        {
            audioSrc.Play();
        }
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
