using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

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
            Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
        }
    }
}
