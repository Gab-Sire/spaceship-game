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
        if (Input.GetKey(ControlsManager.Inputs["Up"]))
        {
            transform.position += new Vector3(0, moveSpeed, 0);
        }
        else if (Input.GetKey(ControlsManager.Inputs["Down"]))
        {
            transform.position -= new Vector3(0, moveSpeed, 0);
        }
        else if (Input.GetKey(ControlsManager.Inputs["Left"]))
        {
            transform.position -= new Vector3(moveSpeed, 0, 0);
        }
        else if(Input.GetKey(ControlsManager.Inputs["Right"]))
        {
            transform.position += new Vector3(moveSpeed, 0, 0);
        }
    }
}
