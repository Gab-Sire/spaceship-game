using UnityEngine;

public class Skyscraper : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField]
    float speed = 10f;

    LevelManager levelManager;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = -transform.right * speed;
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name.Equals("Wall_left"))
        {
            levelManager.LoopSkyscrapers();
            Destroy(gameObject);
        }
    }
}
