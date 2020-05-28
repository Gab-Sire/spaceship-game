using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skyscraper : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float speed = 10f;
    public LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = -transform.right * speed;
    }

    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.name.Contains("Wall_left"))
        {
            levelManager.LoopSkyscrapers();
            Destroy(gameObject);
        }
    }
}
