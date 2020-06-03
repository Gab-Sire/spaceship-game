using UnityEngine;

public class Missile : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    public float rotateSpeed = 100f;
    public Transform target { get; set; }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = (Vector2)target.position - rigidbody2D.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.right).z;
        rigidbody2D.angularVelocity = -rotateAmount * rotateSpeed;
        rigidbody2D.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("enemy"))
        {
            MissileLauncher.target = null;
            Destroy(gameObject, 0.1f);
        }
    }
}
