using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 3f;
    [SerializeField]
    public float maxSpeed = 3f;
    [SerializeField]
    new Rigidbody2D rigidbody2D;
   
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (rigidbody2D.velocity.magnitude < maxSpeed)
            {
                transform.position += new Vector3(0, Input.GetAxis("Vertical"), 0) * moveSpeed;
            }
        }
    }
}
