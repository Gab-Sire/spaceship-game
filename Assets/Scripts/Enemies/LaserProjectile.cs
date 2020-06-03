using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField]
    float speed = 10f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = -transform.right * speed;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("player") || collider.CompareTag("wall"))
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
