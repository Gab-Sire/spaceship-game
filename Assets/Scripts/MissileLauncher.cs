﻿using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject missilePrefab;
    Transform firePoint;
    public static Transform target;
    private Collider selectedCollider;
    private GameObject missile;

    void Start()
    {
        firePoint = GetComponent<Transform>();  
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (target != null && missile == null)
            {
                Debug.Log("instantiating missile");
                missile = Instantiate(missilePrefab, firePoint.transform.position, transform.rotation);
                missile.GetComponent<Missile>().target = target;
            }
        }
    }
}
