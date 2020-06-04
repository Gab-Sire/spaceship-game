using UnityEngine;

public class Bullet : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField]
    float speed = 10f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("enemy") || collider.tag.Contains("wall"))
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
