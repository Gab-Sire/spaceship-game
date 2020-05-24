using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform[] firePoints;

    void Start()
    {
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            foreach (Transform firePoint in firePoints)
            {
                Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
            }
        }
    }
}
