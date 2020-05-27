using UnityEngine;

public class Missile : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float speed = 10f;
    public float rotateSpeed = 100f;
    public Transform target;

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
        if (collider.gameObject.tag.Equals("enemy"))
        {
            MissileLauncher.target = null;
            Destroy(gameObject);
        }
    }
}
